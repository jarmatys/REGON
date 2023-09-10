using REGON.Client;
using REGON.Client.Enums;
using Shouldly;

namespace REGON.Tests;

public class Tests
{
    [TestCase("'RAPID' SPÓŁKA Z OGRANICZONĄ ODPOWIEDZIALNOŚCIĄ W LIKWIDACJI", "P", LegalForm.SPZOO)]
    [TestCase("LUMO-TRANS ŁUKASZ JANKOWIAK", "F", LegalForm.JDG)]
    [TestCase("VOX SPÓŁKA AKCYJNA", "P", LegalForm.SA)]
    [TestCase("Jakub Hachaj Łebski Browar s.c.", "P", LegalForm.SC)]
    [TestCase("ANNA KARPIŃSKA, SYLWIA KARPIŃSKA, ARKADIUSZ KLUSEK SPÓŁKA JAWNA", "P", LegalForm.SJ)]
    [TestCase("PRZEDSIĘBIORSTWO BUDOWLANE RYTTER SPÓŁKA KOMANDYTOWA", "P", LegalForm.SK)]
    [TestCase("DOMKI IZERSKIE SPÓŁKA Z OGRANICZONĄ ODPOWIEDZIALNOŚCIĄ SPÓŁKA KOMANDYTOWA", "P", LegalForm.SPZOOSK)]
    [TestCase("KOPYRA KANCELARIA RADCY PRAWNEGO SPÓŁKA KOMANDYTOWO - AKCYJNA", "P", LegalForm.SKA)]
    public void CheckLegalForm_Should_Return_Proper_Legal_Form(string companyName, string type, LegalForm expectedLegalForm)
    {
        // Arrange & Act
        var legalForm = ClientHelpers.CheckLegalForm(companyName, type);
        
        // Assert
        legalForm.ShouldBe(expectedLegalForm);
    }
    
    [TestCase("'RAPID' SPÓŁKA Z OGRANICZONĄ ODPOWIEDZIALNOŚCIĄ W LIKWIDACJI", true)]
    [TestCase("MILLO SPÓŁKA Z OGRANICZONĄ ODPOWIEDZIALNOŚCIĄ", true)]
    [TestCase("RAMARO TRANSPORT SPÓŁKA Z OGRANICZONĄ ODPOWIEDZIANOŚCIĄ", true)]
    [TestCase("HDS DESIGN STUDIO SPÓŁKA Z OGRANICZONA ODPOWIEDZIALNOŚCIĄ", true)]
    [TestCase("'AnaArt manager' ANASTASIYA KANTSIARUK", false)]
    public void IsSpzoo_Should_Return_Proper_Boolean_Value(string companyName, bool expectedResult)
    {
        // Arrange & Act
        var isSpzoo = ClientHelpers.IsSpzoo(companyName);
        
        // Assert
        isSpzoo.ShouldBe(expectedResult);
    }
    
    [TestCase("'RAPID' SPÓŁKA Z OGRANICZONĄ ODPOWIEDZIALNOŚCIĄ W LIKWIDACJI", false)]
    [TestCase("MILLO SPÓŁKA Z OGRANICZONĄ ODPOWIEDZIALNOŚCIĄ", true)]
    [TestCase("'AnaArt manager' ANASTASIYA KANTSIARUK", true)]
    [TestCase("FROMUSA T.OKOŃ, A.SOCZEWICA SPÓŁKA JAWNA W LIKWIDACJI", false)]
    [TestCase("HALSKY TRANS MARCIN MICHALSKI SPÓŁKA Z OGRANICZONĄ ODPOWIEDZIALNOŚCIĄ W 'LIKWIDACJI'", false)]
    [TestCase("PRZEDSIĘBIORSTWO DRÓG I MOSTÓW SPÓŁKA AKCYJNA W UPADŁOŚCI LIKWIDACYJNEJ", false)]
    [TestCase("KENVIL INVESTMENTS SPÓŁKA Z OGRANICZONĄ ODPOWIEDZIALNOŚCIĄ W LIKWIDACJJI", false)]
    [TestCase("'POL-AN' SPÓŁKA Z OGRANICZONĄ ODPOWIEDZIALNOŚCIĄ W UPADŁOŚCI", false)]
    [TestCase("POMEZANIA SPÓŁKA Z OGRANICZONĄ ODPOWIEDZIALNOŚCIĄ W UPADLOŚCI", false)]
    [TestCase("PRZEDSIĘBIORSTWO HANDLOWE 'PASGALA' WÓJTOWSCY SPÓŁKA JAWNA W UPADŁOŚCI LIKWIDACYJNEJ", false)]
    public void IsActive_Should_Return_Proper_Boolean_Value(string companyName, bool expectedResult)
    {
        // Arrange & Act
        var isActive = ClientHelpers.IsActive(companyName);
        
        // Assert
        isActive.ShouldBe(expectedResult);
    }
}