using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace LanguageExt.Tests
{
    using static Enumerable;
    using static Prelude;
    
    public class SequenceStackSafetyTests
    {
        [Fact(Skip = "This is fixed in the Traverse branch")]
        public void SequenceTry()
        {
            var tries = from i in Range(0, 1_000_000) select Try(() => i);
            var _ = tries.Sequence().Map(Enumerable.Sum).IfFailThrow();
        }
        
        [Fact(Skip = "This is fixed in the Traverse branch")]
        public async Task SequenceTryAsync()
        {
            var tries = from i in Range(0, 1_000_000) select TryAsync(() => Task.FromResult(i));
            var _ = await tries.Sequence().Map(Enumerable.Sum).IfFailThrow();
        }
    }
}
