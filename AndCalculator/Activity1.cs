using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace AndCalculator
{
    [Activity(Label = "AndCalculator", MainLauncher = true, Icon = "@drawable/icon")]
    public class Activity1 : Activity
    {
        enum Operation
        {
            Plus,Subtract,Multiply,Divide,Non
        }

        private EditText inputOutput;
        private decimal firstNumber;
        private Operation operation;
        private const int ERROR_ALERT=0;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            inputOutput = FindViewById<EditText>(Resource.Id.InputOut);
            // Get our button from the layout resource,
            // and attach an event to it
            //Button button = FindViewById<Button>(Resource.Id.MyButton);

            //button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };

            FindViewById<Button>(Resource.Id.buttonOne).Click += (sender,e) =>
                                                                     {
                                                                         inputOutput.Text += "1";
                                                                         inputOutput.SetSelection(inputOutput.Text.Length);
                                                                     };
            FindViewById<Button>(Resource.Id.buttonTwo).Click += (sender, e) =>
                                                                    {
                                                                        inputOutput.Text += "2";
                                                                        inputOutput.SetSelection(inputOutput.Text.Length);
                                                                    };
            FindViewById<Button>(Resource.Id.buttonThree).Click += (sender, e) =>
                                                                    {
                                                                        inputOutput.Text += "3";
                                                                        inputOutput.SetSelection(inputOutput.Text.Length);
                                                                    };
            FindViewById<Button>(Resource.Id.buttonFour).Click += (sender, e) =>
                                                                    {
                                                                        inputOutput.Text += "4";
                                                                        inputOutput.SetSelection(inputOutput.Text.Length);
                                                                    };
            FindViewById<Button>(Resource.Id.buttonFive).Click += (sender, e) =>
                                                                    {
                                                                        inputOutput.Text += "5";
                                                                        inputOutput.SetSelection(inputOutput.Text.Length);
                                                                    };
            FindViewById<Button>(Resource.Id.buttonSix).Click += (sender, e) =>
                                                                    {
                                                                        inputOutput.Text += "6";
                                                                        inputOutput.SetSelection(inputOutput.Text.Length);
                                                                    };
            FindViewById<Button>(Resource.Id.buttonSeven).Click += (sender, e) =>
                                                                    {
                                                                        inputOutput.Text += "7";
                                                                        inputOutput.SetSelection(inputOutput.Text.Length);
                                                                    };
            FindViewById<Button>(Resource.Id.buttonEight).Click += (sender, e) =>
                                                                    {
                                                                        inputOutput.Text += "8";
                                                                        inputOutput.SetSelection(inputOutput.Text.Length);
                                                                    };
            FindViewById<Button>(Resource.Id.buttonNine).Click += (sender, e) =>
                                                                    {
                                                                        inputOutput.Text += "9";
                                                                        inputOutput.SetSelection(inputOutput.Text.Length);
                                                                    };
            FindViewById<Button>(Resource.Id.buttonZero).Click += (sender, e) =>
                                                                    {
                                                                        inputOutput.Text += "0";
                                                                        inputOutput.SetSelection(inputOutput.Text.Length);
                                                                    };
            FindViewById<Button>(Resource.Id.buttonCE).Click += (sender, e) =>
                                                                    {
                                                                        inputOutput.Text = string.Empty;
                                                                        firstNumber = 0;
                                                                        operation = Operation.Non;
                                                                    };
            FindViewById<Button>(Resource.Id.buttonPlus).Click += (sender, e) =>
                                                                      {
                                                                          firstNumber =Convert.ToDecimal(inputOutput.Text);
                                                                          operation=Operation.Plus;
                                                                          inputOutput.Text=string.Empty;
                                                                      };
            FindViewById<Button>(Resource.Id.buttonMinus).Click += (sender, e) =>
                                                                        {
                                                                            firstNumber = Convert.ToDecimal(inputOutput.Text);
                                                                            operation = Operation.Subtract;
                                                                            inputOutput.Text = string.Empty;
                                                                        };
            FindViewById<Button>(Resource.Id.buttonMulti).Click += (sender, e) =>
                                                                        {
                                                                            firstNumber = Convert.ToDecimal(inputOutput.Text);
                                                                            operation = Operation.Multiply;
                                                                            inputOutput.Text = string.Empty;
                                                                        };
            FindViewById<Button>(Resource.Id.buttonDivide).Click += (sender, e) =>
                                                                        {
                                                                            firstNumber = Convert.ToDecimal(inputOutput.Text);
                                                                            operation = Operation.Divide;
                                                                            inputOutput.Text = string.Empty;
                                                                        };
            FindViewById<Button>(Resource.Id.buttonEquile).Click += (sender, e) =>
                                                                        {
                                                                            try
                                                                            {
                                                                                decimal secondNumber = Convert.ToDecimal(inputOutput.Text);
                                                                                decimal result = 0;
                                                                                switch (operation)
                                                                                {
                                                                                    case Operation.Plus:
                                                                                        result = firstNumber +
                                                                                                 secondNumber;
                                                                                        break;
                                                                                    case Operation.Multiply:
                                                                                        result = firstNumber*
                                                                                                 secondNumber;
                                                                                        break;
                                                                                    case Operation.Subtract:
                                                                                        result = firstNumber -
                                                                                                 secondNumber;
                                                                                        break;
                                                                                    case Operation.Divide:
                                                                                        result = firstNumber/
                                                                                                 secondNumber;
                                                                                        break;
                                                                                }

                                                                                inputOutput.Text = result%1==0 ? Convert.ToInt32(result).ToString() : result.ToString();
                                                                                inputOutput.SetSelection(inputOutput.Text.Length);
                                                                            }
                                                                            catch (DivideByZeroException zeo)
                                                                            {
                                                                                inputOutput.Text = string.Empty;
                                                                                ShowDialog(ERROR_ALERT);
                                                                            }
                                                                            catch(Exception ex)
                                                                            {
                                                                                inputOutput.Text = string.Empty;
                                                                                ShowDialog(ERROR_ALERT);
                                                                            }
                                                                        };
        }

        protected override Dialog OnCreateDialog(int id)
        {
            switch (id)
            {
                case ERROR_ALERT:
                    var builder = new AlertDialog.Builder(this);
                   return builder.SetTitle("AndCalculator")
                        .SetMessage("Result is undefined")
                        .SetCancelable(false)
                        .SetPositiveButton("Ok",(o,arg)=> { })
                        .Create();
            }
            return null;
        }
    }
}

