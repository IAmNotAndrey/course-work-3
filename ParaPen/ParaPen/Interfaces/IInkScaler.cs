using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaPen.Interfaces;

public interface IInkScaler
{
	double ZoomFactor { get; set; }
	double CurrentScale { get; }

}
