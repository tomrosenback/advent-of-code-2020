using System.Collections.Generic;
using System.Linq;

namespace Day15
{
    public class Application
    {
        private Dictionary<int, Number> _history;

        class Number
        {
            public int Index { get; set; }
            public int Age { get; set; }
            public int Spoken { get; set; }
        }

        public Application()
        {
            _history = new Dictionary<int, Number>();
        }

        public int PlayGame(List<int> data, int endOfGameNumber = 2020)
        {
            _history.Clear();

            Number prevTurn = new Number();
            int initialDataSize = data.Count;

            for (int i = 0; i < initialDataSize; i++)
            {
                var turn = new Number()
                {
                    Index = i,
                    Age = 0,
                    Spoken = data[i]
                };

                _history.Add(data[i], turn);

                prevTurn = turn;
            }

            for (int i = initialDataSize; i < endOfGameNumber; i++)
            {
                Number turn = new Number()
                {
                    Index = i,
                    Age = _history.ContainsKey(prevTurn.Age) ? i - _history[prevTurn.Age].Index : 0,
                    Spoken = prevTurn.Age
                };

                if (!_history.ContainsKey(turn.Spoken))
                {
                    _history.Add(turn.Spoken, turn);
                }
                else
                {
                    _history[turn.Spoken] = turn;
                }

                prevTurn = turn;
            }

            return prevTurn.Spoken;
        }
    }
}
