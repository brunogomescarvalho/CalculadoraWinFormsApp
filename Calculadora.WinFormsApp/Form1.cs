using CalculadoraClassLib;

namespace CalculadoraWinFormsApp
{
    public partial class Form1 : Form
    {

        public string expressao = "";
        public bool memoriaAtivada = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConstruirExpressao(sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConstruirExpressao(sender);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            ConstruirExpressao(sender);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            ConstruirExpressao(sender);
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            ConstruirExpressao(sender);
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            ConstruirExpressao(sender);
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            ConstruirExpressao(sender);
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            ConstruirExpressao(sender);
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            ConstruirExpressao(sender);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ConstruirExpressao(sender);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            ConstruirExpressao(sender);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            ConstruirExpressao(sender);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            ConstruirExpressao(sender);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ConstruirExpressao(sender);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            LimparTela();
        }
        private void button18_Click(object sender, EventArgs e)
        {
            historicoOperacoes.Items.Clear();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (memoriaAtivada == false)
            {
                button11.BackColor = Color.LightGreen;
                memoriaAtivada = true;
            }
            else
            {
                memoriaAtivada = false;
                button11.BackColor = Color.White;
            }

        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                String[] operacaoArray = expressao.Split(" ");

                decimal valor1 = decimal.Parse(operacaoArray[0]);
                string sinal = operacaoArray[1];
                decimal valor2 = decimal.Parse(operacaoArray[2]);

                Operacao operacao = null!;

                switch (sinal)
                {
                    case "+": operacao = new Adicao(valor1, valor2); break;
                    case "-": operacao = new Subtracao(valor1, valor2); break;
                    case "/": operacao = new Divisao(valor1, valor2); break;
                    case "x": operacao = new Multiplicacao(valor1, valor2); break;

                }

                decimal resultado = operacao.Calcular();
                richTextBox1.Text = resultado.ToString();

                AdicionarNoHistorico($"{expressao} = {resultado}");

                expressao = "";

            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Não é possível efetuar uma divisão por zero.");
                LimparTela();
            }
            catch (FormatException)
            {

            }

        }

        private void ConstruirExpressao(object sender)
        {
            Button btn = (Button)sender;

            bool ehOperador = btn.Tag.ToString() == "operador";

            if (expressao.Contains(' ') && ehOperador)
            {
                int index = expressao.IndexOf(' ');

                string operador = expressao.Substring(index).Trim();

                bool temSegundoValor = operador.Length > 1;

                if (temSegundoValor == false)
                    expressao = expressao.Remove(index, 2) + btn.Text + " ";
            }
            else if (ehOperador && expressao.Length != 0)
                this.expressao += " " + btn.Text + " ";

            else if (ehOperador == false)
                this.expressao += btn.Text;

            richTextBox1.Text = expressao;

        }



        private void AdicionarNoHistorico(string expressao)
        {
            if (historicoOperacoes.Items.Count == 10)
                historicoOperacoes.Items.Clear();

            if (memoriaAtivada == true)
                historicoOperacoes.Items.Add(expressao);
        }

        private void LimparTela()
        {
            richTextBox1.Text = "";
            expressao = "";
        }


    }
}
