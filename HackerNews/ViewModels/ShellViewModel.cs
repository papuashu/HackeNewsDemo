using Microsoft.Xaml.Behaviors.Core;

using PropertyChanged;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HackerNews.ViewModels
{
	[AddINotifyPropertyChangedInterface]
	public class ShellViewModel : Caliburn.Micro.PropertyChangedBase
	{
	}
}
