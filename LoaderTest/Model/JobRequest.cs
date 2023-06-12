using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoaderTest.Model;

public class JobRequest
{
    public int JobBatchId { get; set; }
    public int JobRequestId { get; set; }
    public int JobTypeId { get; set; }
    public int Size { get; set; }
    public int StatusId { get; set; }
    public DateTime UpdatedDate { get; set; }
    public string UpdatedBy { get; set; }
}
