using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NewEmulatorFrontEnd
{
    public partial class SettingsForm : Form
    {
        const string CONSOLE_NAME_PLACEHOLDER = "Console Name";
        const string CONSOLE_EXE_PLACEHOLDER = "Emulator Executable";
        const string CONSOLE_ARGUMENTS_PLACEHOLDER = "Emulator Cmdline Arguments";
        const string ROM_DIRECTORY_PLACEHOLDER = "Rom Directory";

        //structure that stores all information for fields
        class ConsoleFields
        {
            public Label addRow = new Label();
            public TextBox consoleName = new TextBox();
            public TextBox linkToExe = new TextBox();
            public TextBox arguments = new TextBox();
            public TextBox linkToRoms = new TextBox();

            public ConsoleFields(Console c = null)
            {
                if (c == null) return;

                consoleName.Text = c.displayName;
                linkToExe.Text = c.executableDirectory + c.executableName;
                arguments.Text = c.cmdArguments;
                linkToRoms.Text = c.romDirectory;
            }
        }

        //list of all the fields
        List<ConsoleFields> _fields;

        //constructor
        public SettingsForm()
        {
            InitializeComponent();

            //initialize the Labels
            consoleNameLabel.Text = CONSOLE_NAME_PLACEHOLDER;
            executableLabel.Text = CONSOLE_EXE_PLACEHOLDER;
            argumentsLabel.Text = CONSOLE_ARGUMENTS_PLACEHOLDER;
            romDirLabel.Text = ROM_DIRECTORY_PLACEHOLDER;

            consoleNameLabel.Location = new Point(35, 15);
            executableLabel.Location = new Point(165, 15);
            argumentsLabel.Location = new Point(390, 15);
            romDirLabel.Location = new Point(615, 15);

            _fields = new List<ConsoleFields>();

            //add a row for each console
            foreach (Console c in RomManager.GetConsoles())
            {
                AddRow(c);
            }
        }

        //adds a new empty row at the given row number
        ConsoleFields AddRow(Console console = null, int rowNum = -1)
        {
            //calculate the distance down that the row should be
            int distDown = _fields.Count;
            int topBuffer = 0;
            int rowHeight = 25;

            //if we are insterting, move all the otehr rows down first
            if (rowNum >= 0)
            {
                //move the rows down
                for (int i = rowNum; i < _fields.Count; i++)
                {
                    _fields[i].addRow.Location = new Point(_fields[i].addRow.Location.X, _fields[i].addRow.Location.Y + rowHeight);
                    _fields[i].arguments.Location = new Point(_fields[i].arguments.Location.X, _fields[i].arguments.Location.Y + rowHeight);
                    _fields[i].consoleName.Location = new Point(_fields[i].consoleName.Location.X, _fields[i].consoleName.Location.Y + rowHeight);
                    _fields[i].linkToExe.Location = new Point(_fields[i].linkToExe.Location.X, _fields[i].linkToExe.Location.Y + rowHeight);
                    _fields[i].linkToRoms.Location = new Point(_fields[i].linkToRoms.Location.X, _fields[i].linkToRoms.Location.Y + rowHeight);
                }
                distDown = rowNum;
            }

            //create and position the controls
            ConsoleFields cf = new ConsoleFields(console);
            Point p = new Point( 5, distDown * rowHeight + topBuffer - settingsContainer.VerticalScroll.Value);

            cf.addRow.Text = "+";
            cf.addRow.Width = 20;
            cf.addRow.Location = p;

            p.X += cf.addRow.Width;
            p.Y += 15;

            cf.consoleName = new TextBox();
            cf.consoleName.Width = 125;
            cf.consoleName.Location = p;

            p.X += cf.consoleName.Width + 5;

            cf.linkToExe = new TextBox();
            cf.linkToExe.Width = 220;
            cf.linkToExe.Location = p;

            p.X += cf.linkToExe.Width + 5;

            cf.arguments = new TextBox();
            cf.arguments.Width = 220;
            cf.arguments.Location = p;

            p.X += cf.arguments.Width + 5;

            cf.linkToRoms= new TextBox();
            cf.linkToRoms.Width = 220;
            cf.linkToRoms.Location = p;

            //add the callbacks
            //insert button callbacks
            cf.addRow.MouseEnter +=
                delegate(object sender, EventArgs e)
                {
                    cf.addRow.ForeColor = Color.Black;
                };
            cf.addRow.MouseLeave +=
                delegate(object sender, EventArgs e)
                {
                    cf.addRow.ForeColor = Color.Gray;
                };
            cf.addRow.Click +=
                delegate(object sender, EventArgs e)
                {
                    AddRow(null, _fields.IndexOf(cf));
                };

            //text field callbacks
            EventHandler textAddedCallback = delegate(object sender, EventArgs e)
                {
                    //if the text has changed and it's not gray or empty
                    if ((sender as TextBox).Text.Trim() == "")
                    {
                        return;
                    }

                    //then add a new row at the bottom
                    if (_fields.Contains(cf) && _fields.IndexOf(cf) == _fields.Count - 1) AddRow();
                };

            cf.consoleName.TextChanged += textAddedCallback;
            cf.linkToExe.TextChanged += textAddedCallback;
            cf.arguments.TextChanged += textAddedCallback;
            cf.linkToRoms.TextChanged += textAddedCallback;

            EventHandler highlightRowOnFocus = delegate(object sender, EventArgs e)
                {
                    Color col = Color.FromArgb(235, 255, 235);
                    cf.arguments.BackColor = col;
                    cf.consoleName.BackColor = col;
                    cf.linkToExe.BackColor = col;
                    cf.linkToRoms.BackColor = col;
                };

            cf.arguments.GotFocus += highlightRowOnFocus;
            cf.consoleName.GotFocus += highlightRowOnFocus;
            cf.linkToExe.GotFocus += highlightRowOnFocus;
            cf.linkToRoms.GotFocus += highlightRowOnFocus;

            EventHandler dehighlightRowOnUnfocus = delegate(object sender, EventArgs e)
                {
                    cf.arguments.BackColor = Color.White;
                    cf.consoleName.BackColor = Color.White;
                    cf.linkToExe.BackColor = Color.White;
                    cf.linkToRoms.BackColor = Color.White;
                };

            cf.arguments.LostFocus += dehighlightRowOnUnfocus;
            cf.consoleName.LostFocus += dehighlightRowOnUnfocus;
            cf.linkToExe.LostFocus += dehighlightRowOnUnfocus;
            cf.linkToRoms.LostFocus += dehighlightRowOnUnfocus;


            //initialize visuals of the insert button   
            Font plusFont = new Font("", 14, FontStyle.Regular);
            cf.addRow.ForeColor = Color.Gray;
            cf.addRow.Font = plusFont;

            //add the controls to the form
            settingsContainer.Controls.Add(cf.addRow);
            settingsContainer.Controls.Add(cf.consoleName);
            settingsContainer.Controls.Add(cf.linkToExe);
            settingsContainer.Controls.Add(cf.arguments);
            settingsContainer.Controls.Add(cf.linkToRoms);

            _fields.Insert(distDown, cf);

            RefreshTabOrder();

            return cf;
        }

        //cycle through and refresh the tab order of the fields
        void RefreshTabOrder()
        {
            for (int i = 0; i < _fields.Count; i++)
            {
                ConsoleFields cf = _fields[i];
                int tabCount = i * 5;
                cf.addRow.TabIndex = tabCount;
                cf.consoleName.TabIndex = tabCount + 1;
                cf.linkToExe.TabIndex = tabCount + 2;
                cf.arguments.TabIndex = tabCount + 3;
                cf.linkToRoms.TabIndex = tabCount + 4;
            }
        }

        #region Cancel and Save Buttons
        //close without doing anything if cancel is pressed
        private void CancelButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        //save the settings and close when the save button is pressed
        private void SaveButtonClick(object sender, EventArgs e)
        {
            List<Console> newConsoles = new List<Console>();

            //convert to game console objects
            foreach (ConsoleFields cf in _fields)
            {
                string displayName = cf.consoleName.Text.Trim();
                string execPath = cf.linkToExe.Text.Trim();
                string cmdArguments = cf.arguments.Text.Trim();
                string romDirectory = cf.linkToRoms.Text.Trim();

                Console c = new Console(execPath, displayName, cmdArguments, romDirectory);
                newConsoles.Add(c);
            }

            RomManager.SaveOutNewConsoleDirectories(newConsoles);
            Close();
        }
        #endregion
        
        private void SettingsForm_Load(object sender, EventArgs e) { }
    }
}
