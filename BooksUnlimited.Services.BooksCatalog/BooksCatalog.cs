using System.Collections.Generic;
using System.Fabric;
using System.Threading.Tasks;
using BooksUnlimited.Services.BooksCatalog.Abstractions;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Remoting.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;

namespace BooksUnlimited.Services.BooksCatalog
{
    /// <summary>
    /// An instance of this class is created for each service instance by the Service Fabric runtime.
    /// </summary>
    internal sealed class BooksCatalog : StatelessService, IBooksCatalogService
    {
        public BooksCatalog(StatelessServiceContext context)
            : base(context)
        { }

        public Task<IList<Book>> GetBooksAsync()
        {
            var books = new[]
            {
                new Book { Title = "The Martian", Author = "Andy Weir", Genre = "Science Fiction", Summary = "When astronauts blast off from the planet Mars, they leave behind Mark Watney, presumed dead after a fierce storm. With only a meager amount of supplies, the stranded visitor must utilize his wits and spirit to find a way to survive on the hostile planet. Meanwhile, back on Earth, members of NASA and a team of international scientists work tirelessly to bring him home, while his crew mates hatch their own plan for a daring rescue mission."},
                new Book { Title = "We Are Legion (We Are Bob)", Author = "Dennis E. Taylor", Genre = "Science Fiction", Summary = "Bob Johansson has just sold his software company and is looking forward to a life of leisure. There are places to go, books to read, and movies to watch. So it's a little unfair when he gets himself killed crossing the street. Bob wakes up a century later to find that corpsicles have been declared to be without rights, and he is now the property of the state. He has been uploaded into computer hardware and is slated to be the controlling AI in an interstellar probe looking for habitable planets. The stakes are high: no less than the first claim to entire worlds.If he declines the honor, he'll be switched off, and they'll try again with someone else. If he accepts, he becomes a prime target.There are at least three other countries trying to get their own probes launched first, and they play dirty. The safest place for Bob is in space, heading away from Earth at top speed. Or so he thinks.Because the universe is full of nasties, and trespassers make them mad - very mad." },
                new Book { Title = "Our Mathematical Universe", Author = "Max Tegmark", Genre = "Non Fiction", Summary = "Max Tegmark's doorstopper of a book takes aim at three great puzzles: how large is reality? What is everything made of? Why is our universe the way it is? Tegmark, a professor of physics at MIT, writes at the cutting edge of cosmology and quantum theory in friendly and relaxed prose, full of entertaining anecdotes and down-to-earth analogies. His book seeks to induct the reader into a wildly speculative cosmic vision of infinite time and space and infinite parallel universes. Close to his heart is an extreme Pythagorean/Platonic thesis: physical reality is ultimately nothing other than a giant mathematical totality." },
                new Book { Title = "Life 3.0", Author = "Max Tegmark", Genre = "Non Fiction", Summary = "How will Artificial Intelligence affect crime, war, justice, jobs, society and our very sense of being human? The rise of AI has the potential to transform our future more than any other technology--and there's nobody better qualified or situated to explore that future than Max Tegmark, an MIT professor who's helped mainstream research on how to keep AI beneficial." }
            };

            return Task.FromResult((IList<Book>)books);
        }

        /// <summary>
        /// Optional override to create listeners (e.g., TCP, HTTP) for this service replica to handle client or user requests.
        /// </summary>
        /// <returns>A collection of listeners.</returns>
        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            return new[]
            {
                new ServiceInstanceListener(context => this.CreateServiceRemotingListener(context))
            };
        }
    }
}
