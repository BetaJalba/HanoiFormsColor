using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BelGiocoHanoi
{
    public partial class FormHanoi : Form
    {
        public FormHanoi()
        {
            InitializeComponent();
        }

        CCalcolatore gioco;

        private void FormHanoi_Load(object sender, EventArgs e)
        {
            DATGRDVIEW.RowCount = 21;
            DATGRDVIEW.ColumnCount = 61;
            DATGRDVIEW.AutoSize = false;
            DATGRDVIEW.ScrollBars = ScrollBars.None;
            DATGRDVIEW.ColumnHeadersVisible = false;
            DATGRDVIEW.RowHeadersVisible = false;
            DATGRDVIEW.AllowUserToResizeColumns = false;
            DATGRDVIEW.AllowUserToResizeRows = false;

            for (int i = 0; i < DATGRDVIEW.RowCount; i++)
            {
                DataGridViewColumn column = DATGRDVIEW.Columns[i];
                column.MinimumWidth = 2;
                column.Width = DATGRDVIEW.Width / DATGRDVIEW.ColumnCount;
                DataGridViewRow row = DATGRDVIEW.Rows[i];
                row.MinimumHeight = 2;
                row.Height = DATGRDVIEW.Height / DATGRDVIEW.RowCount;
            }

            for (int i = DATGRDVIEW.RowCount; i < DATGRDVIEW.ColumnCount; i++)
            {
                DataGridViewColumn column = DATGRDVIEW.Columns[i];
                column.MinimumWidth = 2;
                column.Width = DATGRDVIEW.Width / DATGRDVIEW.ColumnCount;
            }
        }

        private void DATGRDVIEW_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DATGRDVIEW_SelectionChanged(object sender, EventArgs e)
        {
            DATGRDVIEW.SelectionChanged -= DATGRDVIEW_SelectionChanged;

            DATGRDVIEW.ClearSelection();
            DATGRDVIEW.SelectionChanged += DATGRDVIEW_SelectionChanged;
        }

        private void BTNCALC_Click(object sender, EventArgs e)
        {
            try
            {
                presenzaErrori();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                return;
            }

            gioco = new CCalcolatore((int)TXTNUM.Value);
            gioco.AvviaGioco();

            passo = -1;

            resetGrid();
            createDisks();
            createGrid();
            fillTowers();
            fillDisks(true);
        }

        private void presenzaErrori()
        {
            if (TXTNUM.Value == 0 || TXTNUM.Value > 13)
                throw new Exception("Inserire numeri da 1 a 13");
        }

        private void resetGrid()
        {
            for (int i = 0; i < DATGRDVIEW.ColumnCount; ++i)
                for (int j = 0; j < DATGRDVIEW.RowCount; j++)
                    DATGRDVIEW.Rows[j].Cells[i].Style.BackColor = Color.White;
        }

        List<CDisco> dischi;
        private void createDisks()
        {
            dischi = new List<CDisco>();

            int size = 1;
            for (int i = 0; i < (int)TXTNUM.Value; i++)
            {
                size += 2;
                CDisco disco = new CDisco(size);
                dischi.Add(disco);
            }
        }
        private void createGrid()
        {
            //se 1 allora = (1 (spazio lato) + (1 + (n + 2)) * 3) + 1
            int columnCount = (dischi.Last().size + 1) * 3 + 1;
            int rowCount = (int)TXTNUM.Value + 3;

            DATGRDVIEW.ColumnCount = columnCount;
            DATGRDVIEW.RowCount = rowCount;

            for (int i = 0; i < DATGRDVIEW.RowCount; i++)
            {
                DataGridViewColumn column = DATGRDVIEW.Columns[i];
                column.MinimumWidth = 2;
                //column.Width = DATGRDVIEW.Width / DATGRDVIEW.ColumnCount;
                DataGridViewRow row = DATGRDVIEW.Rows[i];
                row.MinimumHeight = 2;
                row.Height = DATGRDVIEW.Height / DATGRDVIEW.RowCount;
            }

            for (int i = DATGRDVIEW.RowCount; i < DATGRDVIEW.ColumnCount; i++)
            {
                DataGridViewColumn column = DATGRDVIEW.Columns[i];
                column.MinimumWidth = 2;
                //column.Width = DATGRDVIEW.Width / DATGRDVIEW.ColumnCount;
            }
        }

        int[] colonne; //salva la posizione delle colonne
        int[] valoreColonne;
        int passo;

        private void fillTowers()
        {
            colonne = new int[3];
            int colonneIndex = 0;
            int daRipetere = (DATGRDVIEW.ColumnCount - 1) / 3;
            int ripetuto = 0;
            Color selectedColor = Color.SandyBrown;

            for (int i = 0; i < DATGRDVIEW.ColumnCount; i++)
            {
                if (ripetuto == daRipetere / 2)
                {
                    for (int j = 0; j < DATGRDVIEW.RowCount; j++)
                        DATGRDVIEW.Rows[j].Cells[i].Style.BackColor = selectedColor; //colora tutta la colonna
                    colonne[colonneIndex] = i;
                    colonneIndex++;
                }

                else if (ripetuto > 0)
                    DATGRDVIEW.Rows[DATGRDVIEW.RowCount - 1].Cells[i].Style.BackColor = selectedColor;

                ripetuto++;
                if (ripetuto >= daRipetere)
                    ripetuto = 0;
            }
        }

        private void fillDisks(bool a)
        {
            if (a)
                passo++;
            else 
                passo--;
            valoreColonne = gioco.GetPosizioneDischi(passo);
            //controlla se ogni potenza di 2 è presente
            int esponente = (int)TXTNUM.Value - 1;
            for (int i = 0; i < 3; i++) //per ogni colonna 
            {
                int rigaPartenza = DATGRDVIEW.RowCount - 2; //parte da sopra la base della colonna
                for (int j = esponente; j >= 0; j--) //esponente continua diminuendo
                    if (valoreColonne[i] >= Math.Pow(2, j)) //disco presente
                    {
                        //si prende la posizione della colonna, si tiene conto della riga e ci si disegna
                        CDisco discoConsiderato = dischi[j]; //si tiene conto dell'offset
                        int cellaPartenza = colonne[i] - discoConsiderato.size / 2; //si torna indietro di tanti passi quanto sono la grandezza della colonna /2 e troncato

                        for (int k = 0; k < discoConsiderato.size; k++) //riempie di colore una striscia di lunghezza del disco considerato
                            DATGRDVIEW.Rows[rigaPartenza].Cells[cellaPartenza + k].Style.BackColor = discoConsiderato.Color;

                        rigaPartenza--;
                        valoreColonne[i] -= (int)Math.Pow(2, j);
                    }
            }
        }

        private void BTNNEXTMOVE_Click(object sender, EventArgs e)
        {
            resetGrid();
            fillTowers();
            try
            {
                fillDisks(true);
            }
            catch
            {
                MessageBox.Show("Hai terminato il numero di mosse possibili");
            }
        }

        private void BTNPREVMOVE_Click(object sender, EventArgs e)
        {
            resetGrid();
            fillTowers();
            try
            {
                fillDisks(false);
            }
            catch
            {
                MessageBox.Show("Sei già all'inizio");
            }
        }
    }
}
