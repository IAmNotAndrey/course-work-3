   M S B A M L   `   `   `  ����Z  VGraphSharp.Controls, Version=1.1.0.0, Culture=neutral, PublicKeyToken=f9c24778325a6b82V>clr-namespace:GraphSharp.Controls;assembly=GraphSharp.ControlsGraphSharp.Controls  5      B >ParaPen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ParaPen.ViewsParaPen.Views 5      7 clr-namespace:ParaPen.ModelViewsParaPen.ModelViews 5      ]3clr-namespace:ParaPen.Models.CustomGraph.BlockNodes%ParaPen.Models.CustomGraph.BlockNodes 5	      "   ParaPen.Views.BlockDiagramUC   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Mgc>clr-namespace:GraphSharp.Controls;assembly=GraphSharp.Controls     5      -localclr-namespace:ParaPen.Views     5      /mv clr-namespace:ParaPen.ModelViews     5      Bcg3clr-namespace:ParaPen.Models.CustomGraph.BlockNodes     5	        � 	Resources  5       �� DataType5  /ParaPen.Models.CustomGraph.BlockNodes.BlockNode �� 
TargetType �� Triggers �� Binding �� Value �� Property �� Value8  2ParaPen.Models.CustomGraph.BlockNodes.TerminalNode �� CornerRadius%   GraphSharp.Controls.EdgeControl	 P� Property
 P� Value��%  (��       5      *, +)(��     5.      *, +)'      �� 5      "  6   .R�5      �� $��1q�6   ��5      �� 5      " ��6    5      �� 5   	    6   �� *IsHighlighted+ True67   .a�5   
   ��  � ��
 � ���6(   �� 5   
    � ��$ 4q�6,   5   
   �� 5    	    6   �� *IsHighlighted+	 False67   .a�5!   
   ��  � ��
 �   �6(   �� 5#   
    � ��$ 2q�6,   5$   
   5&      ._�5(      �� $��Center=�5)      $��Center=�5*      ��5(      �� *Label+5*      5+      5,      �� 5.      "  6   .R�5/      �� $��1q�6   $ 5��6    ��50      �� 51      " ��6    54      �� 56   	    6   �� *IsHighlighted+ True67   .a�57   
   ��  � ��
 � ���6(   �� 59   
    � ��$ 4q�6,   5:   
   �� 5<   	    6   �� *IsHighlighted+	 False67   .a�5=   
   ��  � ��
 �   �6(   �� 5?   
    � ��$ 2q�6,   5@   
   5B      ._�5D      �� $��Center=�5E      $��Center=�5F      ��5D      �� *Label+5F      5G      5H      �� 5K      "  6
    5L      P� 5M      	 �@J�IsMouseOver$

 True��6%   . �5N      ��  � ��
 �  ��6$   �� 5O       �@�Cursor$
 Hand��6    5P      5R      5T      .��5V      � .+�5W      %   GraphSharp.Controls.GraphLayout  -   5          Name$ graphLayout��5W      �   �GraphSharp.Controls.GraphLayout`3[[System.Object, System.Runtime, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[QuickGraph.IEdge`1[[System.Object, System.Runtime, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], QuickGraph, Version=3.6.61114.0, Culture=neutral, PublicKeyToken=f3fb40175eec2af3],[QuickGraph.IBidirectionalGraph`2[[System.Object, System.Runtime, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a],[QuickGraph.IEdge`1[[System.Object, System.Runtime, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], QuickGraph, Version=3.6.61114.0, Culture=neutral, PublicKeyToken=f3fb40175eec2af3]], QuickGraph, Version=3.6.61114.0, Culture=neutral, PublicKeyToken=f3fb40175eec2af3]]   LayoutAlgorithmType$ EfficientSugiyama��5X      "   OverlapRemovalAlgorithmType$	 FSA��5Y      5[      5a      5b      