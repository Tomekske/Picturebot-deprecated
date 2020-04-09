using Xunit;

namespace Picturebot.Tests
{
    public class FlowTests
    {
        [Theory]
        [InlineData(@"D:\Pictures\Zakopane 05-02-2020\RAW\test.NEF", @"D:\Pictures", 1, @"D:\Pictures\Zakopane 05-02-2020\RAW\Zakopane_05-02-2020_00001.NEF")]
        [InlineData(@"D:\Pictures\London 05-02-2020\RAW\Zakopane_05-02-2020_1.NEF", @"D:\Pictures", 1, @"D:\Pictures\London 05-02-2020\RAW\London_05-02-2020_00001.NEF")]
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

        [Theory]
        [InlineData(@"D:\Pictures\Zakopane 05-02-2020\RAW\Zakopane_05-02-2020_00006.NEF", @"D:\Pictures", 1, @"D:\Pictures\Zakopane 05-02-2020\RAW\pb_00001_5aa4c4c329.NEF")]
        [InlineData(@"D:\Pictures\Zakopane 05-02-2020\RAW\Zakopane_05-02-2020_00006.jpg", @"D:\Pictures", 22, @"D:\Pictures\Zakopane 05-02-2020\RAW\pb_00022_13df43533d.jpg")]
        public void Get_HashFromPath_Postive(string path, string workspace, int index, string expected)
        {
            #region Initialize
            Picture picture = new Picture(path, workspace, index);
            var config = Configuration.Read();
            Flow flow = new Flow(config[0]);
            #endregion Initialize

            #region Test
            string actual = flow.HashRenamePicture(picture);
            #endregion Test

            #region Assert
            Assert.Equal(expected, actual);
            #endregion Assert
        }
    }
}
