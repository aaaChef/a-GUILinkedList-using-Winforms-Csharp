using System;
using System.Collections.Generic;
namespace GUIL
{
    public partial class Form1 : Form
    {
        Linkedlist ls = new Linkedlist();
        private List<Panel> panels = new List<Panel>(); // List to keep track of panels
        private int nextPanelY = 0; // Y position for the next panel
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Enter value:", "Input", "");

            if (!string.IsNullOrWhiteSpace(input))
            {
                // Create a new panel
                Panel newPanel = new Panel();
                newPanel.BorderStyle = BorderStyle.FixedSingle;
                newPanel.Size = new Size(200, 80); // Increased height for two buttons

                // Calculate the position of the new panel
                int newX = button1.Location.X + button1.Width + 10;
                newPanel.Location = new Point(newX, nextPanelY);

                // Increment nextPanelY for the next panel's position
                nextPanelY += newPanel.Height + 10;

                // Create a textbox inside the new panel
                TextBox textBox = new TextBox();
                textBox.Size = new Size(150, 20);
                textBox.Location = new Point(10, 10);
                textBox.Text = input;
                textBox.ReadOnly = true;
                ls.insertat(0,Convert.ToByte( input));
                 Console.WriteLine();

                // Create two buttons below the textbox
                Button button2 = new Button();
                button2.Text = "Delete";
                button2.Size = new Size(75, 23);
                button2.Location = new Point(10, 40);
                button2.Click += (sender, e) => Button2_Click(newPanel); // Attach event handler

                Button button3 = new Button();
                button3.Text = "Insert";
                button3.Size = new Size(75, 23);
                button3.Location = new Point(90, 40);
                button3.Click += Button3_Click; // Attach event handler

                // Add controls to the panel
                newPanel.Controls.Add(textBox);
                newPanel.Controls.Add(button2);
                newPanel.Controls.Add(button3);

                
                panels.Insert(0, newPanel);

                // Add the new panel to the form
                this.Controls.Add(newPanel);

                // Adjust the positions of all panels
                AdjustPanelPositions();
            }
        }

        // Event handler for button2 click
        private void Button2_Click(Panel panelToRemove)
        {
            // Remove the panel from the form
            this.Controls.Remove(panelToRemove);
            

            int index = panels.FindIndex(a => a.Contains(panelToRemove));
            ls.removebyindex(index);
            Console.WriteLine();

            // Remove the panel from the list
            panels.Remove(panelToRemove);

            // Adjust the positions of subsequent panels
            AdjustPanelPositions();
        }

        // Event handler for button3 click
        private void Button3_Click(object sender, EventArgs e)
        {
            // Get the button that was clicked
            Button clickedButton = sender as Button;

            // Find the index of the panel associated with the clicked button
            int index = -1;
            for (int i = 0; i < panels.Count; i++)
            {
                if (panels[i].Controls.Contains(clickedButton))
                {
                    index = i;
                    break;
                }
            }

            if (index != -1)
            {
                // Prompt user for input
                string input = Microsoft.VisualBasic.Interaction.InputBox("Enter value:", "Input", "");

                if (!string.IsNullOrWhiteSpace(input))
                {
                    // Create a new panel below the current panel
                    // Create a new panel
                    Panel newPanel = new Panel();
                    newPanel.BorderStyle = BorderStyle.FixedSingle;
                    newPanel.Size = new Size(200, 80); // Increased height for two buttons

                    // Create a textbox inside the new panel
                    TextBox textBox = new TextBox();
                    textBox.Size = new Size(150, 20);
                    textBox.Location = new Point(10, 10);
                    textBox.Text = input;
                    textBox.ReadOnly = true;

                    // Create two buttons below the textbox
                    Button button2 = new Button();
                    button2.Text = "Delete";
                    button2.Size = new Size(75, 23);
                    button2.Location = new Point(10, 40);
                    button2.Click += (sender, e) => Button2_Click(newPanel); // Attach event handler

                    Button button3 = new Button();
                    button3.Text = "Inseret";
                    button3.Size = new Size(75, 23);
                    button3.Location = new Point(90, 40);
                    button3.Click += Button3_Click; // Attach event handler

                    // Add controls to the panel
                    newPanel.Controls.Add(textBox);
                    newPanel.Controls.Add(button2);
                    newPanel.Controls.Add(button3);

                    // Add the new panel after the panel associated with the clicked button
                    panels.Insert(index + 1, newPanel);
                    ls.insertat(index + 1, Convert.ToByte(input));
                    Console.WriteLine();

                    // Add the new panel to the form
                    this.Controls.Add(newPanel);

                    // Adjust the positions of all panels
                    AdjustPanelPositions();
                }
            }
        }

        // Helper method to adjust positions of subsequent panels
        private void AdjustPanelPositions()
        {
            nextPanelY = 0;
            foreach (var panel in panels)
            {
                //   panel.Location = new Point(panel.Location.X, nextPanelY);
                int newX = button1.Location.X + button1.Width + 10;
                panel.Location = new Point(newX, nextPanelY);
                nextPanelY += panel.Height + 10;
            }
        }
    }
}
