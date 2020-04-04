using Xunit;

namespace Picturebot.Tests
{
    public class FlowTests
    {
        [Theory]
        [InlineData(@"D:\Pictures\Zakopane 05-02-2020\RAW\test.NEF", @"D:\Pictures", 1, "Zakopane_05-02-2020_00001.NEF")]
        [InlineData(@"D:\Pictures\London 05-02-2020\RAW\Zakopane_05-02-2020_1.NEF", @"D:\Pictures", 1, "London_05-02-2020_00001.NEF")]
        public void Rename_FlowPictureNames(string path, string workspace, int index, string expected)
        {
            #region Initialize
            Picture picture = new Picture(path, workspace, index);
            var config = Configuration.Read();
            Flow flow = new Flow(config[0]);
            #endregion Initialize

            #region Test
            picture.Filename = flow.RenamePicture(picture);
            #endregion Test

            #region Assert
            Assert.Equal(expected, picture.Filename);
            #endregion Assert
        }
    }
}
