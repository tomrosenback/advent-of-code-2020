using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    public class Application
    {
        public Application()
        {
            Bags = new List<Bag>();
        }

        public Application(string file)
        {
            Bags = HelperMethods.GetRows(file, x =>
            {
                return new Bag(x);
            }).ToList();
        }

        public IEnumerable<Bag> Bags { get; set; }

        public IEnumerable<Bag> GetParentBags(string color)
        {
            return GetParentBags(Bags.Where(b => b.Color != color && b.NestedBags.Count > 0).Select(b => b), color);
        }

        private IEnumerable<Bag> GetParentBags(IEnumerable<Bag> bags, string color)
        {
            List<Bag> parents = new List<Bag>();

            foreach (var bag in bags)
            {
                if (bag.Color == color || (bag.NestedBags.Count > 0 && CanFitChild(bag.NestedBags, color)))
                {
                    parents.Add(bag);
                }
            }

            return parents;
        }

        public bool CanFitChild(IEnumerable<Bag> bags, string color)
        {
            foreach (var bag in bags)
            {
                if (bag.NestedBags.Count == 0 && bag.Color == color)
                {
                    return true;
                }
                else if (bag.NestedBags.Count > 0 && CanFitChild(bag.NestedBags, color))
                {
                    return true;
                }

                var parent = Bags.Where(b => b.Color == bag.Color && b.Color != color).First();

                if (parent != null && parent.NestedBags.Count > 0 && CanFitChild(parent.NestedBags, color))
                {
                    return true;
                }

            }

            return false;
        }

        public long GetBagContent(string color)
        {
            var myBag = Bags.Where(b => b.Color == color).First();
            return GetBagContent(myBag, color);
        }

        public long GetBagContent(Bag myBag, string color)
        {
            long sum = 0;

            foreach (var bag in myBag.NestedBags)
            {
                if (bag.Color == color)
                {
                    continue;
                }

                sum += bag.MaxAmount;

                var child = Bags.Where(b => b.Color == bag.Color && b.Color != color && b.NestedBags.Count > 0);

                if (child != null && child.Any())
                {
                    sum += GetBagContent(child.First(), color) * bag.MaxAmount;
                }
            }

            return sum;
        }
    }
}
