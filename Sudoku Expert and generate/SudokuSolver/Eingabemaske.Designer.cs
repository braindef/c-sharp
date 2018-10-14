namespace SudokuSolver
{
    partial class Eingabemaske

    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {

            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    enter(i, j);

            System.Windows.Forms.Label RekText = new System.Windows.Forms.Label();
            RekText.Left = 30;
            RekText.Top = 233;
            RekText.Width = 80;
            RekText.Text = "Rekursionstiefe:";
            this.Controls.Add(RekText);
            RekText.Show();

            System.Windows.Forms.TextBox Rekursion = new System.Windows.Forms.TextBox();
            Rekursion.Top = 230;
            Rekursion.Left = 115;
            Rekursion.Width = 20;
            Rekursion.Text = "3";
            Rekursion.Show();
            this.Controls.Add(Rekursion);

            System.Windows.Forms.Button Reset = new System.Windows.Forms.Button();
            Reset.Top = 230;
            Reset.Left = 145;
            Reset.Width = 50;
            Reset.Text = "Reset";
            Reset.Show();
            this.Controls.Add(Reset);

            Reset.Click += delegate
            {
                for (int i = 0; i < 9; i++)
                    for (int j = 0; j < 9; j++)
                    {
                        Brett[i, j].Text = "";
                        Tree.solution[i, j] = 0;
                    }
            

                


            };

            System.Windows.Forms.Button Start = new System.Windows.Forms.Button();
            Start.Left = 200;
            Start.Top = 230;
            Start.Text = "Solve";
            Start.Click += delegate 
            {  
                myTree = new Tree(sudoku, 0, 0, sudoku[0, 0], System.Int32.Parse(Rekursion.Text));
                AusgabeFenster myAF = new AusgabeFenster();
                myAF.init();
                
            
            };
            this.Controls.Add(Start);
            Start.Show();
            
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "Form1";
        }

        #endregion
    }

}
