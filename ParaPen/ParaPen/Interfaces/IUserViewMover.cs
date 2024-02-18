using ParaPen.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ParaPen.Interfaces;

public interface IUserViewMover
{
    event EventHandler<OffsetEventArgs> UserViewOffsetChanged;
    double MovementSpeed { get; set; }
}
