using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proglang
{
    public partial class Form1 : Form
    {
        private string commaSeparatedTokens;
        private string Separator;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;

            
            string[] tokens = CustomTokenizer(input);

            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

            int counter = tokens.Length;

            
            textBox2.Text = string.Join(" ", tokens);

           
            commaSeparatedTokens = string.Join(", ", tokens);
            Separator = string.Join(" ", tokens);

            
            textBox3.Text = commaSeparatedTokens;

            
            textBox4.Text = "Number of tokens: " + counter.ToString();

            
            CategorizeTokens(tokens);

        }
        private string[] CustomTokenizer(string input)
        {
            List<string> tokens = new List<string>();
            StringBuilder currentToken = new StringBuilder();

            foreach (char c in input)
            {
                if (char.IsLetterOrDigit(c)) 
                {
                    currentToken.Append(c);
                }
                else if (c == ' ' || c == '=') 
                {
                    if (currentToken.Length > 0)
                    {
                        tokens.Add(currentToken.ToString());
                        currentToken.Clear();
                    }
                }
                else if (char.IsPunctuation(c))
                {
                    if (currentToken.Length > 0)
                    {
                        tokens.Add(currentToken.ToString());
                        currentToken.Clear();
                    }
                    tokens.Add(c.ToString()); 
                }
            }

            
            if (currentToken.Length > 0)
            {
                tokens.Add(currentToken.ToString());
            }

            return tokens.ToArray();
        }

        private void CategorizeTokens(string[] tokens)
        {
           
            label5.Text = "";       
            label6.Text = "";        
            label7.Text = "";       
            label8.Text = "";        

            foreach (string token in tokens)
            {
                if (IsWord(token))
                {
                    label5.Text += token + Environment.NewLine; 
                }
                else if (IsPunctuations(token))
                {
                    label6.Text += token + Environment.NewLine; 
                }
                else if (IsNumber(token))
                {
                    label7.Text += token + Environment.NewLine; 
                }
                else if (IsAlphanumeric(token))
                {
                    label8.Text += token + Environment.NewLine; 
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Separator))
            {


                
                string trimmedTokens = Separator.Replace(" ", "");

                
                char[] charArray = trimmedTokens.ToCharArray();

                
                string result = string.Join(" - ", charArray);

                
                label10.Text = result;
            }

        }

        
        private bool IsWord(string token)
        {
            return token.All(char.IsLetter) && !token.Any(char.IsDigit);
        }

        private bool IsPunctuations(string token)
        {
            return token.All(c => !char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c) && char.IsPunctuation(c));
        }

        private bool IsNumber(string token)
        {
            return token.All(char.IsDigit);
        }

        private bool IsAlphanumeric(string token)
        {
            return token.Any(char.IsLetter) && token.Any(char.IsDigit);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
