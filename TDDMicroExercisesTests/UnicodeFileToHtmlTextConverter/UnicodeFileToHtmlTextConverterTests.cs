using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO.Abstractions.TestingHelpers;

namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter.Tests
{
    [TestClass()]
    public class UnicodeFileToHtmlTextConverterTests
    {
        #region Test Methods
        [TestMethod]
        [DataRow("c:\\myfile.txt", "", "", DisplayName = "Should Convert Empty Text File")]
        [DataRow("c:\\myfile1.txt", "test123", "test123<br />", DisplayName = "Should Convert Single Line ASCII Text File")]
        [DataRow("c:\\myfile2.txt", "first\r\nsecond", "first<br />second<br />", DisplayName = "Should Convert Muliple Lines ASCII File")]
        [DataRow("c:\\myfile3.txt", "test123!%&", "test123!%&amp;<br />", DisplayName = "Should Convert Single Line Unicode Text File")]
        [DataRow("c:\\myfile4.txt", "first *\r\nsecond &", "first *<br />second &amp;<br />", DisplayName = "Should Convert Muliple Lines Unicode Text File")]
        [DataRow("c:\\myfile5.txt", @"! # $ % & ' ( ) * + , - . / 0 1 2 3 4 5 6 7 8 9 : ; < = > ? @ A B C D E F G H I J K L M N O P Q R S T U V W X Y Z [ \ ] ^ _ ` a b c d e f g h i j k l m n o p q r s t u v w x y z { | } ~", @"! # $ % &amp; &#39; ( ) * + , - . / 0 1 2 3 4 5 6 7 8 9 : ; &lt; = &gt; ? @ A B C D E F G H I J K L M N O P Q R S T U V W X Y Z [ \ ] ^ _ ` a b c d e f g h i j k l m n o p q r s t u v w x y z { | } ~<br />", DisplayName = "Should Convert Basic Latin Unicode Text File")]
        [DataRow("c:\\myfile6.txt", @"ʹ ͵ ͺ ; ΄ ΅ Ά · Έ Ή Ί Ό Ύ Ώ ΐ Α Β Γ Δ Ε Ζ Η Θ Ι Κ Λ Μ Ν Ξ Ο Π Ρ Σ Τ Υ Φ Χ Ψ Ω Ϊ Ϋ ά έ ή ί ΰ α β γ δ ε ζ η θ ι κ λ μ ν ξ ο π ρ ς σ τ υ φ χ ψ ω ϊ ϋ ό ύ ώ ϐ ϑ ϒ ϓ ϔ ϕ ϖ Ϛ Ϝ Ϟ Ϡ Ϣ ϣ Ϥ ϥ Ϧ ϧ Ϩ ϩ Ϫ ϫ Ϭ ϭ Ϯ ϯ ϰ ϱ ϲ ϳ", @"ʹ ͵ ͺ ; ΄ ΅ Ά · Έ Ή Ί Ό Ύ Ώ ΐ Α Β Γ Δ Ε Ζ Η Θ Ι Κ Λ Μ Ν Ξ Ο Π Ρ Σ Τ Υ Φ Χ Ψ Ω Ϊ Ϋ ά έ ή ί ΰ α β γ δ ε ζ η θ ι κ λ μ ν ξ ο π ρ ς σ τ υ φ χ ψ ω ϊ ϋ ό ύ ώ ϐ ϑ ϒ ϓ ϔ ϕ ϖ Ϛ Ϝ Ϟ Ϡ Ϣ ϣ Ϥ ϥ Ϧ ϧ Ϩ ϩ Ϫ ϫ Ϭ ϭ Ϯ ϯ ϰ ϱ ϲ ϳ<br />", DisplayName = "Should Convert Greek Unicode Text File")]
        public void ConvertToHtmlTest(string fileName, string fileText, string expectedConvertedHtmlText)
        {
            // Arrange
            MockFileSystem mockFileSystem = new MockFileSystem(new Dictionary<string, MockFileData>
            {
                { fileName, new MockFileData(fileText) }
            });
            UnicodeFileToHtmlTextConverter textConverter = new UnicodeFileToHtmlTextConverter(mockFileSystem, fileName);

            // Act
            string actualConvertedHtmlText = textConverter.ConvertToHtml();

            // Assert
            Assert.AreEqual<string>(actualConvertedHtmlText, expectedConvertedHtmlText);
        }
        #endregion
    }
}