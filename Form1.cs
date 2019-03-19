using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Media;
using System.Diagnostics;


namespace Fort_Worth_Call_Alarm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // This program once the user clicks engage will check to see if notepad is running
        // if notepad is running then nothing should happen and it should keep checking
        // if notepad is not running it should play an alarm sound

            //bool wait acts as a flag for method
        static bool wait;

        //appRunning method is what checks for specified process running
        public void appRunning(string appName = "communicatork9")          // Replace appName = "_____" <-- enter what ever process listed in taskmanager without the .exe
        {

            
         
            Process[] ProcessList = Process.GetProcesses();

            foreach (Process p in ProcessList)
            {

                   
                if (p.ProcessName.Contains(appName))
                {

                    wait = true;
                    break;

                    

                }
                else
                {
                    
                
                    wait = false;
                    
                }
                if (wait)
                {

                    checkAgain(appName);
                }
                

            }
            
        
            
        }
        public void checkAgain(string p)
        {
          
            appRunning(p);
        }

        public void ringthealarm(bool wait = false)
        {
            if (wait == false)
            {

                   SoundPlayer alarm = new SoundPlayer(@"C:\windows\media\alarm10.wav");
                   alarm.PlayLooping();
               
            }
            else
            {
               if(wait)
                {


                }
                    
                    }

        }


        // Engage button
        private void button1_Click(object sender, EventArgs e)
        {
            
               label1.Visible = true;
               label1.ForeColor = Color.Red;
            
            appRunning();
               label2.Visible = true;
            MessageBox.Show("monitoring");       // For some reason program crashes when
            while (wait)
            {

                appRunning();

            }
            if (wait == false)
            {

                ringthealarm();

            }



        }

        
                    
                    
           
                       
        
                
         // RESET BUTTON
        private void button2_Click(object sender, EventArgs e)
        {
         
            label1.Visible = false;
            SoundPlayer stopsound = new SoundPlayer(@"C\windows\media\Alarm10.wav");
            stopsound.Stop();
            label2.Visible = false;
            
        }

    }
}

