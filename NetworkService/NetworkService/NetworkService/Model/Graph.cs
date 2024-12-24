using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkService.Model
{
    public class Graph : ClassINotifyPropertyChanged
    {
        private double height1;
        public double Height1
        {
            get { return height1; }
            set
            {
                Height2 = height1;
                height1 = value;
                OnPropertyChanged("Height1");
            }
        }

        private string fill1;
        public string Fill1
        {
            get { return fill1; }
            set
            {
                Fill2 = fill1;
                fill1 = value;
                OnPropertyChanged("Fill1");
            }
        }

        private double height2;
        public double Height2
        {
            get { return height2; }
            set
            {
                Height3 = height2;
                height2 = value;
                OnPropertyChanged("Height2");
            }
        }


        private string fill2;
        public string Fill2
        {
            get { return fill2; }
            set
            {
                Fill3 = fill2;
                fill2 = value; ;
                OnPropertyChanged("Fill2");
            }
        }

        private double height3;
        public double Height3
        {
            get { return height3; }
            set
            {
                Height4 = height3;
                height3 = value;
                OnPropertyChanged("Height3");
            }
        }

        private string fill3;
        public string Fill3
        {
            get { return fill3; }
            set
            {
                Fill4 = fill3;
                fill3 = value;
                OnPropertyChanged("Fill3");
            }
        }

        private double height4;
        public double Height4
        {
            get { return height4; }
            set
            {
                Height5 = height4;
                height4 = value;
                OnPropertyChanged("Height4");
            }
        }


        private string fill4;
        public string Fill4
        {
            get { return fill4; }
            set
            {
                Fill5 = fill4;
                fill4 = value;
                OnPropertyChanged("Fill4");
            }
        }

        private double height5;
        public double Height5
        {
            get { return height5; }
            set
            {
                height5 = value;
                OnPropertyChanged("Height5");
            }
        }

        private string fill5;
        public string Fill5
        {
            get { return fill5; }
            set
            {
                fill5 = value;
                OnPropertyChanged("Fill5");
            }
        }
    }
}
