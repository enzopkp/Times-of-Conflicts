using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Age_Of_War
{
    public class Player
    {
        private string _name;
        private List<Buff> _buffs;
        public int Money { get; set; }

        public Player()
        {
            Money = 300;
        }
    }
}
