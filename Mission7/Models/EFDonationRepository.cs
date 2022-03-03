using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Mission7.Models
{
    public class EFDonationRepository : IDonationRepository
    {
        private BookstoreContext context;

        public EFDonationRepository (BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<Donation> Donations => context.Donations.Include(x => x.Lines).ThenInclude(x => x.Books);

        public void SaveDonation(Donation donation)
        {
            context.AttachRange(donation.Lines.Select(x => x.Books));

            if (donation.DonationId == 0)
            {
                context.Donations.Add(donation);
            }

            context.SaveChanges();
        }
    }
}
