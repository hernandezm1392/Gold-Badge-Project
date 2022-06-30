using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    public class ClaimQueue
    {
        private readonly Queue<ClaimsDepartment> _queueRepository = new Queue<ClaimsDepartment>();

        public bool AddClaimToQueue(ClaimsDepartment claim)
        {
            if(claim != null)
            {
                _queueRepository.Enqueue(claim);
                return true;
            }
            return false;
        }

        public Queue<ClaimsDepartment> GetClaims()
        {
            return _queueRepository;
        }

        public ClaimsDepartment ViewNextClaim()
        {
            if(_queueRepository.Count > 0)
            {
                ClaimsDepartment claim = _queueRepository.Peek();
                return claim;
            }
            return null;
        }

        public bool DiscardClaim()
        {
                ClaimsDepartment claim = ViewNextClaim();

                if(claim is null)
                {
                        return false;
                }

                _queueRepository.Dequeue();
                return true;
        }
    }