using System;
using System.Collections.Generic;
using System.Text;

namespace HabitsTracker
{
    class Habit
    {
        public int Number { get; set; } = 0;

        public Habit()
        {
            Number++;
        }
    }
}
