using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkService.Model
{
    public class Filter
    {
        public string Name { get; set; }
        public string SelectedType { get; set; }
        public string IdFilterValue { get; set; }
        public bool IsLessThanSelected { get; set; }
        public bool IsGreaterThanSelected { get; set; }
        public bool IsEqualSelected { get; set; }
    }

   

}
