// Created by Richard Moss - https://www.cyotek.com/blog/dragging-items-in-a-listbox-control-with-visual-insertion-guides
// Dragging items in a ListBox control with visual insertion guides
// http://www.cyotek.com/blog/dragging-items-in-a-listbox-control-with-visual-insertion-guides

namespace PicturebotGUI
{
  /// <summary>
  /// Determines the insertion mode of a drag operation
  /// </summary>
  internal enum InsertionMode
  {
    /// <summary>
    /// None
    /// </summary>
    None,

    /// <summary>
    /// The source item will be inserted before the destination item
    /// </summary>
    Before,

    /// <summary>
    /// The source item will be inserted after the destination item
    /// </summary>
    After
  }
}
