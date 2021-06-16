using System.Collections.Generic;
using SportStore.Entities;

namespace SportStore.Seed
{
    public class LessonsSeed : BaseSeed<Lesson>
    {
        public override IEnumerable<Lesson> GetData()
        {
            return new[] { new Lesson() };
        }
    }
}