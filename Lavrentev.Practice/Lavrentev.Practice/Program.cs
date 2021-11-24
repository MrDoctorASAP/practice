using System;

namespace Lavrentev.Practice
{
    public class Program
    {
        private static void Main()
        {
            Presentation.Presentation presentation = new Presentation.Presentation();
            
            while(true)
            {
                presentation.Show();
            }
        }
    }
}
