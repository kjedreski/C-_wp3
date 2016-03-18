using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using System.Numerics;



namespace projec3_alpha
{
    public partial class _Default : Page
    {
        string[] Types;
        string[] Methods1;
        string[] Methods2;
        List<string> box1 = new List<string>();
        List<string> box2 = new List<string>();
        string file;
        string Tname1;
        Assembly DLL;
        protected void Page_Load(object sender, EventArgs e)
        {
            hide_AllOps();
            //load in DLL
            loadDLL();

            List<string> types = new List<string>();
            List<string> methods1 = new List<string>();
            List<string> methods2 = new List<string>();
            string[] test;
            int counter = 0;
            // label4.Text = DLL.GetName;
            // lists are dynamically sized arrays
            // .ToArray at end.
            // find all types and stow in list
            foreach (Type t in DLL.GetTypes())
            {
                types.Add(t.ToString());
                /*First, let's gather names of all methods */
                // MessageBox.Show();
                //dynamically find all types
                //  richTextBox1.Text += t.ToString() + '\n'+'\n';
                foreach (MethodInfo m in t.GetMethods())
                {
                    if (counter == 0)
                    {
                        methods1.Add(m.ToString());
                        //  richTextBox1.Text += m.ToString() + '\n';
                    }
                    else if (counter == 1)
                    {
                        methods2.Add(m.ToString());
                        // richTextBox1.Text += m.ToString() + '\n';
                    }
                }
                counter++;
                //   richTextBox1.Text += '\n';
            }
            //Now make both lists arrays
            Types = types.ToArray();
            Methods2 = methods2.ToArray();
            Methods1 = methods1.ToArray();
        }

        private void hide_AllOps()
        {
            /*Simple*/
            Button2.Visible = false;
            Button3.Visible = false;
            Button4.Visible = false;
            Button5.Visible = false;
            Button6.Visible = false;
            Button7.Visible = false;
            Button8.Visible = false;
            Button9.Visible = false;
            /*Complex */
        }

        private void rsetLists()
        {
            //box1.Clear
            //box2.Clear
        }

        private void loadDLL()
        {
           DLL = Assembly.LoadFrom("C://inetpub//wwwroot//WP_s2016//kaj61//bin//calc.dll");
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            hide_AllOps();
            rsetLists();
            //Result2.Text = "simple";
            // reset and hide all available operations
            // reset  lists


            /*on click make calc */
            // box1 is Simple operations
            // box2 is Complex operations
            foreach (ListItem itemChecked in CheckBoxList1.Items)
            {
                if (itemChecked.Selected)
                {
                    box1.Add(itemChecked.ToString()); 
                }
            }


            foreach (ListItem itemChecked in CheckBoxList2.Items)
            {
                if (itemChecked.Selected)
                {
                    box2.Add(itemChecked.ToString());
                }
            }
            // throw ALL items that are checked in lists, and convert to array
            string[] SimpleBox = box1.ToArray();
            string[] ComplexBox = box2.ToArray();

            /*Now invoke reflection and instantiate a calculator */
            /*Methods1 is Simple.  Methods2 is Complex. */
            /*BIG ASS LOOP */

            //MessageBox.Show(Types[0]);
            foreach (string method in SimpleBox)
            {
                /*Instantiate a Simple calculator real time */
                //save code below for later ***********
                
                if (method == "add")
                {
                    Button2.Visible = true;
                }
                else if (method == "subtract")
                {
                    Button3.Visible = true;
                }
                else if (method == "multiply")
                {
                    Button4.Visible = true;
                }
                else if (method == "divide")
                {
                    Button5.Visible = true;;
                }
                //**************************************
                //groupBox1.Hide();

            }
            foreach (string method in ComplexBox)
            {
                /*Now invoke reflection and instantiate a calculator */
                /*Methods1 is Simple.  Methods2 is Complex. */
                /*Instantiate a Complex calculator real time */
                if (method == "add")
                {
                    Button6.Visible = true;
                }
                else if (method == "subtract")
                {
                    Button7.Visible = true;
                }
                else if (method == "multiply")
                {
                    Button8.Visible = true;
                }
                else if (method == "divide")
                {
                    Button9.Visible = true;
                }
            }  
        }

        
        private void clearTextBoxes()
        {
            /* */
            TextBox1.Text = "";
            TextBox2.Text = "";
            Real1.Text = "";
            Complex1.Text = "";
            Real2.Text = "";
            Complex2.Text = "";
        }

        private void invokeSimple(string operation)
        {
            Type typeC = DLL.GetType("SimpleMath");
            float arg1 = Convert.ToSingle(TextBox2.Text);
            float arg2 = Convert.ToSingle(TextBox1.Text);
            // clear text boxes here.
            clearTextBoxes();
            //MessageBox.Show(typeC.GetMethod("Add"));
            Object obj = Activator.CreateInstance(typeC);
            MethodInfo method = typeC.GetMethod(operation);
            AnswerBox.Text = Convert.ToString(method.Invoke(obj, new object[] { arg1, arg2 }));
        }

        private void invokeComplex(string operation)
        {
            Type typeC = DLL.GetType("ComplexMath");
            // complex num 1
            float r1 = Convert.ToSingle(Real1.Text);
            float i1 = Convert.ToSingle(Complex1.Text);
            float r2 = Convert.ToSingle(Real2.Text);
            float i2 = Convert.ToSingle(Complex2.Text);

            var arg1 = new cFloat(r1, i1);
            var arg2 = new cFloat(r2, i2);
            // clear text boxes here.
            clearTextBoxes();
            //MessageBox.Show(typeC.GetMethod("Add"));
            Object obj = Activator.CreateInstance(typeC);
            MethodInfo method = typeC.GetMethod(operation);
            var result = method.Invoke(obj, new object[] { arg1, arg2 });
            Type typeD = DLL.GetType("cFloat");
            Result2.Text = Convert.ToString(typeD.GetMethod("getReal").Invoke(result, new object[] {}));
            Result3.Text = Convert.ToString(typeD.GetMethod("getImg").Invoke(result, new object[] { }));
            /*if (result.GetType() == typeof(cFloat)){
                cFloat meta = result.
            }
            //Result2.Text = Convert.ToString(method.Invoke(obj, new object[] { arg1, arg2 }));
            method = */
        }

        /*Simple Operation  */
      /*  private void button5_Click(object sender, EventArgs e)
        {
            invokeSimple("add");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            invokeSimple("subtract");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            invokeSimple("multiply");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            invokeSimple("divide");
        }
        /*End simple operation button controls 
     
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
        // okay, stop ignoring


        // COMPLEX operations start here *****************
        private void button6_Click(object sender, EventArgs e)
        {
            invokeComplex("Add");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            invokeComplex("Subtract");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            invokeComplex("Multiply");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            invokeComplex("Divide");
        }

        */
        /*BELOW simple ops */
        protected void Button2_Click1(object sender, EventArgs e)
        {
            invokeSimple("add");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            invokeSimple("subtract");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            invokeSimple("multiply");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            invokeSimple("divide");
        }
        /*END simple ops */

        /*START complex ops */
        protected void Button6_Click(object sender, EventArgs e)
        {
            invokeComplex("add");
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            invokeComplex("subtract");
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            invokeComplex("multiply");
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            invokeComplex("divide");
        }
    }
 
    }
