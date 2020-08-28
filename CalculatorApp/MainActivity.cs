using Android.App;
using Android.Widget;
using Android.OS;
using System;
using System.Data;


namespace CalculatorApp
{
    [Activity(Label = "CalculatorApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
           
            //Buttons to receive user input
            Button num1 = (Button)FindViewById(Resource.Id.btn1);
            Button num2 = (Button)FindViewById(Resource.Id.btn2);
            Button num3 = (Button)FindViewById(Resource.Id.btn3);
            Button num4 = (Button)FindViewById(Resource.Id.btn4);
            Button num5 = (Button)FindViewById(Resource.Id.btn5);
            Button num6 = (Button)FindViewById(Resource.Id.btn6);
            Button num7 = (Button)FindViewById(Resource.Id.btn7);
            Button num8 = (Button)FindViewById(Resource.Id.btn8);
            Button num9 = (Button)FindViewById(Resource.Id.btn9);
            Button num0 = (Button)FindViewById(Resource.Id.btn0);
            
            //Buttons that receive user mathematical operators
            Button equ = (Button)FindViewById(Resource.Id.btnEql);
            Button clr = (Button)FindViewById(Resource.Id.btnDel);
            Button dot = (Button)FindViewById(Resource.Id.btnDot);
            Button div = (Button)FindViewById(Resource.Id.btnDiv);
            Button mul = (Button)FindViewById(Resource.Id.btnMul);
            Button add = (Button)FindViewById(Resource.Id.btnAdd);
            Button sub = (Button)FindViewById(Resource.Id.btnSub);

            //text area to receive and display the user input
            EditText resu = (EditText)FindViewById(Resource.Id.resultText);
            
            //Text area to display the result generated after calculations
            EditText resu2 = (EditText)FindViewById(Resource.Id.resultText2);
            
            //Whenever the text in the EditText Changes the expression in the EditText is being computed.
            resu.TextChanged += delegate 
            {

                if (resu.Text == "")
                {
                    resu2.Text = "";
                }

                string x = resu.Text;
                try
                {
                    //Computation of the expression
                    double result = Convert.ToDouble(new DataTable().Compute(x, null));
                    resu2.Text = result.ToString();
                }
                catch (Exception exc)
                {
                    //No action to be performed
                }
            };

            num1.Click += delegate { resu.Text = resu.Text + num1.Text.ToString(); };
            num2.Click += delegate { resu.Text = resu.Text + num2.Text.ToString(); };
            num3.Click += delegate { resu.Text = resu.Text + num3.Text.ToString(); };
            num4.Click += delegate { resu.Text = resu.Text + num4.Text.ToString(); };
            num5.Click += delegate { resu.Text = resu.Text + num5.Text.ToString(); };
            num6.Click += delegate { resu.Text = resu.Text + num6.Text.ToString(); };
            num7.Click += delegate { resu.Text = resu.Text + num7.Text.ToString(); };
            num8.Click += delegate { resu.Text = resu.Text + num8.Text.ToString(); };
            num9.Click += delegate { resu.Text = resu.Text + num9.Text.ToString(); };
            num0.Click += delegate { resu.Text = resu.Text + num0.Text.ToString(); };

            dot.Click += delegate 
            {
                string x = resu.Text;
                int l = x.Length;
                if (l != 0)
                {
                    string x2 = x.Substring(l - 1, 1);
                    if (x2 != ".")
                    {
                        if (x2 == "-" || x2 == "*" || x2 == "/" || x2 == "+")
                        {
                            string s1 = x.Substring(0, l - 1);
                            resu.Text = s1;
                        }
                        resu.Text = resu.Text + dot.Text.ToString();
                    }
                }
            };

            add.Click += delegate 
            {
                string x = resu.Text;
                int l = x.Length;
                if (l != 0)
                {
                    string x2 = x.Substring(l - 1, 1);
                    if (x2 != "+")
                    {
                        if (x2 == "-" || x2 == "*" || x2 == "/" || x2 == ".")
                        {
                            string s1 = x.Substring(0, l - 1);
                            resu.Text = s1;
                        }
                        resu.Text = resu.Text + add.Text.ToString();
                    }
                }
            };
            sub.Click += delegate 
            {
                string x = resu.Text;
                int l = x.Length;
                if (l != 0)
                {
                    string x2 = x.Substring(l - 1, 1);
                    if (x2 != "-")
                    {
                        if (x2 == "+" || x2 == "*" || x2 == "/" || x2 == ".")
                        {
                            string s1 = x.Substring(0, l - 1);
                            resu.Text = s1;
                        }
                        resu.Text = resu.Text + sub.Text.ToString();
                    }
                }
            };
            mul.Click += delegate 
            {
                string x = resu.Text;
                int l = x.Length;
                if (l != 0)
                {
                    string x2 = x.Substring(l - 1, 1);
                    if (x2 != "*")
                    {
                        if (x2 == "-" || x2 == "+" || x2 == "/" || x2 == ".")
                        {
                            string s1 = x.Substring(0, l - 1);
                            resu.Text = s1;
                        }
                        resu.Text = resu.Text + "*";
                    }
                }
            };
            div.Click += delegate 
            {
                string x = resu.Text;
                int l = x.Length;
                if (l != 0)
                {
                    string x2 = x.Substring(l - 1, 1);
                    if (x2 != "/")
                    {
                        if (x2 == "-" || x2 == "*" || x2 == "+" || x2 == ".")
                        {
                            string s1 = x.Substring(0, l - 1);
                            resu.Text = s1;
                        }
                        resu.Text = resu.Text + div.Text.ToString();
                    }
                }
            };
            clr.Click += delegate 
            {
                string x = resu.Text;
                int l = x.Length;
                if (l != 0)
                {
                    string x2 = x.Substring(0, l - 1);
                    resu.Text = x2;
                    if (x2.Length != 0)
                    {
                        string x3 = x2.Substring(l - 2, 1);
                        if (x3 == "+" || x3 == "-" || x3 == "*" || x3 == "/" || x3 == ".")
                        {
                            try
                            {
                                double result = Convert.ToDouble(new DataTable().Compute(x.Substring(0, l - 2), null));
                                resu2.Text = result.ToString();
                            }
                            catch (Exception exc)
                            {
                            }
                        }
                    }
                }
            };
            equ.Click += delegate 
            {
                if (resu2.Text != "")
                {
                    resu.Text = resu2.Text;
                    resu2.Text = "";
                }
            };

        }

        private void Resu_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}

