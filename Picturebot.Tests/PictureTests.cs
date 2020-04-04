using Xunit;

namespace Picturebot.Tests
{
    public class PictureTests
    {
        [Theory]
        [InlineData(@"D:\Pictures\Zakopane 05-02-2020\RAW\Zakopane_05-02-2020_00006.NEF", @"D:\Pictures", 1, ".NEF")]
        [InlineData(@"D:\Pictures\Zakopane 05-02-2020\RAW\Zakopane_05-02-2020_00006.png", @"D:\Pictures", 1, ".png")]
        public void Get_ExtenstionFromPicture_Postive(string path, string workspace, int index, string expected)
        {
            #region Initialize
            Picture picture = new Picture(path, workspace, index);
            #endregion Initialize

            #region Test
            string actual = picture.Extension;
            #endregion Test

            #region Assert
            Assert.Equal(expected, actual);
            #endregion Assert
        }

        [Theory]
        [InlineData(@"D:\Pictures\Zakopane 05-02-2020\RAW\Zakopane_05-02-2020_00006.NEF", @"D:\Pictures", 1, ".jpg")]
        [InlineData(@"D:\Pictures\Zakopane 05-02-2020\RAW\Zakopane_05-02-2020_00006.png", @"D:\Pictures", 1, ".jpg")]
        public void Get_ExtenstionFromPicture_Negative(string path, string workspace, int index, string expected)
        {
            #region Initialize
            Picture picture = new Picture(path, workspace, index);
            #endregion Initialize

            #region Test
            string actual = picture.Extension;
            #endregion Test

            #region Assert
            Assert.NotEqual(expected, actual);
            #endregion Assert
        }

        [Theory]
        [InlineData(@"D:\Pictures\Zakopane 05-02-2020\RAW\Zakopane_05-02-2020_00006.NEF", @"D:\Pictures", 1, "Zakopane 05-02-2020")]
        [InlineData(@"D:\Pictures\Zakopane 10 05-02-2020\RAW\Zakopane_05-02-2020_00006.NEF", @"D:\Pictures", 1, "Zakopane 10 05-02-2020")]
        [InlineData(@"D:\Pictures\London 05-02-2020\RAW\Zakopane_05-02-2020_00006.png", @"D:\Pictures", 1, "London 05-02-2020")]
        [InlineData(@"D:\Pictures\London Soho 05-02-2020\RAW\Zakopane_05-02-2020_00006.png", @"D:\Pictures", 1, "London Soho 05-02-2020")]
        [InlineData(@"D:\Pictures\Belgium Antwerpen Schoten 05-02-2020\RAW\Zakopane_05-02-2020_00006.png", @"D:\Pictures", 1, "Belgium Antwerpen Schoten 05-02-2020")]
        [InlineData(@"D:\Pictures\Belgium Antwerpen Schoten 50 05-02-2020\RAW\Zakopane_05-02-2020_00006.png", @"D:\Pictures", 1, "Belgium Antwerpen Schoten 50 05-02-2020")]
        public void Get_ShootNameFromPath_Postive(string path, string workspace, int index, string expected)
        {
            #region Initialize
            Picture picture = new Picture(path, workspace, index);
            #endregion Initialize

            #region Test
            string actual = picture.ShootInfo;
            #endregion Test

            #region Assert
            Assert.Equal(expected, actual);
            #endregion Assert
        }

        [Theory]
        [InlineData(@"D:\Pictures\Zakopane 05-02-2020\RAW\Zakopane_05-02-2020_00006.NEF", @"D:\Pictures", 1, "dsfsdf 05-02-2020")]
        [InlineData(@"D:\Pictures\Zakopane 10 05-02-2020\RAW\Zakopane_05-02-2020_00006.NEF", @"D:\Pictures", 1, "dsfsdf 10 05-02-2020")]
        [InlineData(@"D:\Pictures\London 05-02-2020\RAW\Zakopane_05-02-2020_00006.png", @"D:\Pictures", 1, "dsfsdfsd 05-02-2020")]
        [InlineData(@"D:\Pictures\London Soho 05-02-2020\RAW\Zakopane_05-02-2020_00006.png", @"D:\Pictures", 1, "sdfds Soho 05-02-2020")]
        [InlineData(@"D:\Pictures\Belgium Antwerpen Schoten 05-02-2020\RAW\Zakopane_05-02-2020_00006.png", @"D:\Pictures", 1, "Belsdfsdfgium Antwerpen Schoten 05-02-2020")]
        [InlineData(@"D:\Pictures\Belgium Antwerpen Schoten 10 05-02-2020\RAW\Zakopane_05-02-2020_00006.png", @"D:\Pictures", 1, "Belsdfsdfgium Antwerpen Schoten 10 05-02-2020")]
        public void Get_ShootNameFromPath_Negative(string path, string workspace, int index, string expected)
        {
            #region Initialize
            Picture picture = new Picture(path, workspace, index);
            #endregion Initialize

            #region Test
            string actual = picture.ShootInfo;
            #endregion Test

            #region Assert
            Assert.NotEqual(expected, actual);
            #endregion Assert
        }

        [Theory]
        [InlineData(@"D:\Pictures\Zakopane 05-02-2020\RAW\Zakopane_05-02-2020_00006.NEF", @"D:\Pictures", 1, "05-02-2020")]
        [InlineData(@"D:\Pictures\Zakopane 05-02-2020\Zakopane_05-02-2020_00006.NEF", @"D:\Pictures", 1, "05-02-2020")]
        [InlineData(@"D:\Zakopane 05-02-2020\Zakopane_05-02-2020_00006.NEF", @"D:\Pictures", 1, "05-02-2020")]
        public void Get_DateFromPath_Postive(string path, string workspace, int index, string expected)
        {
            #region Initialize
            Picture picture = new Picture(path, workspace, index);
            #endregion Initialize

            #region Test
            string actual = picture.Date;
            #endregion Test

            #region Assert
            Assert.Equal(expected, actual);
            #endregion Assert
        }

        [Theory]
        [InlineData(@"D:\Pictures\Zakopane\RAW\Zakopane_05-02-2020_00006.NEF", @"D:\Pictures", 1, "")]
        [InlineData(@"D:\Pictures\Zakopane\Zakopane_05-02-2020_00006.NEF", @"D:\Pictures", 1, "")]
        [InlineData(@"D:\Zakopane\Zakopane_05-02-2020_00006.NEF", @"D:\Pictures", 1, "")]
        public void Get_DateFromPath_Negative(string path, string workspace, int index, string expected)
        {
            #region Initialize
            Picture picture = new Picture(path, workspace, index);
            #endregion Initialize

            #region Test
            string actual = picture.Date;
            #endregion Test

            #region Assert
            Assert.Equal(expected, actual);
            #endregion Assert
        }

        [Theory]
        [InlineData(@"D:\Pictures\Zakopane 05-02-2020\RAW\Zakopane_05-02-2020_00006.NEF", @"D:\Pictures", 1, "Zakopane")]
        [InlineData(@"D:\Pictures\Zakopane 10 05-02-2020\RAW\Zakopane_05-02-2020_00006.NEF", @"D:\Pictures", 1, "Zakopane 10")]
        [InlineData(@"D:\Pictures\London 05-02-2020\RAW\Zakopane_05-02-2020_00006.png", @"D:\Pictures", 1, "London")]
        [InlineData(@"D:\Pictures\London Soho 05-02-2020\RAW\Zakopane_05-02-2020_00006.png", @"D:\Pictures", 1, "London Soho")]
        [InlineData(@"D:\Pictures\Belgium Antwerpen Schoten 05-02-2020\RAW\Zakopane_05-02-2020_00006.png", @"D:\Pictures", 1, "Belgium Antwerpen Schoten")]
        [InlineData(@"D:\Pictures\Belgium Antwerpen Schoten 50 05-02-2020\RAW\Zakopane_05-02-2020_00006.png", @"D:\Pictures", 1, "Belgium Antwerpen Schoten 50")]
        public void Get_NameFromPath_Postive(string path, string workspace, int index, string expected)
        {
            #region Initialize
            Picture picture = new Picture(path, workspace, index);
            #endregion Initialize

            #region Test
            string actual = picture.Name;
            #endregion Test

            #region Assert
            Assert.Equal(expected, actual);
            #endregion Assert
        }

        [Theory]
        [InlineData(@"D:\Pictures\05-02-2020\RAW\Zakopane_05-02-2020_00006.NEF", @"D:\Pictures", 1, "")]
        [InlineData(@"D:\Pictures\05-02-2020\Zakopane_05-02-2020_00006.NEF", @"D:\Pictures", 1, "")]
        public void Get_NameFromPath_Negative(string path, string workspace, int index, string expected)
        {
            #region Initialize
            Picture picture = new Picture(path, workspace, index);
            #endregion Initialize

            #region Test
            string actual = picture.Name;
            #endregion Test

            #region Assert
            Assert.Equal(expected, actual);
            #endregion Assert
        }

        [Theory]
        [InlineData(@"D:\Pictures\05-02-2020\RAW\Zakopane_05-02-2020_00006.NEF", @"D:\Pictures", 1, "RAW")]
        [InlineData(@"D:\Pictures\05-02-2020\Instagram\Zakopane_05-02-2020_00006.NEF", @"D:\Pictures", 1, "Instagram")]
        public void Get_FlowFromPath_Postive(string path, string workspace, int index, string expected)
        {
            #region Initialize
            Picture picture = new Picture(path, workspace, index);
            #endregion Initialize

            #region Test
            string actual = picture.Flow;
            #endregion Test

            #region Assert
            Assert.Equal(expected, actual);
            #endregion Assert
        }
        [Theory]
        [InlineData(@"D:\Pictures\05-02-2020\RAW\Zakopane_05-02-2020_00006.NEF", @"D:\Pictures", 1, @"Pictures\05-02-2020\RAW\Zakopane_05-02-2020_00006.NEF")]
        [InlineData(@"D:\Pictures\05-02-2020\Instagram\Zakopane_05-02-2020_00006.NEF", @"D:\Pictures", 1, @"Pictures\05-02-2020\Instagram\Zakopane_05-02-2020_00006.NEF")]
        public void Get_RelativeFromPath_Postive(string path, string workspace, int index, string expected)
        {
            #region Initialize
            Picture picture = new Picture(path, workspace, index);
            #endregion Initialize

            #region Test
            string actual = picture.Relative;
            #endregion Test

            #region Assert
            Assert.Equal(expected, actual);
            #endregion Assert
        }

        [Theory]
        [InlineData(@"D:\Pictures\Zakopane 05-02-2020\RAW\Zakopane_05-02-2020_00006.NEF", @"D:\Pictures", 1, "Zakopane_05-02-2020_00006")]
        [InlineData(@"D:\hello\there\Pictures\Zakopane 05-02-2020\Instagram\Zakopane_05-02-2020_00006.NEF", @"D:\hello\there", 1, "Zakopane_05-02-2020_00006")]
        public void Get_FilenameFromPath_Postive(string path, string workspace, int index, string expected)
        {
            #region Initialize
            Picture picture = new Picture(path, workspace, index);
            #endregion Initialize

            #region Test
            string actual = picture.Filename;
            #endregion Test

            #region Assert
            Assert.Equal(expected, actual);
            #endregion Assert
        }
    }
}
