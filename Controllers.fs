namespace FSharpCore.Controllers

open System
open System.Linq
open System.Net.Http
open System.Collections.Generic
open System.Threading.Tasks
open Microsoft.AspNetCore.Mvc
open FSharpCore.Models
open Microsoft.Extensions.Logging
open FSharp.Data

type HomeController() = 
    inherit Controller()

    //this is the base page of the site
    [<HttpGet>]
    member this.Index() = 
        
        let data: Language = { 
            LanguageDescription = "Hindi";
            LanguageCode = "hi-HN"; 
            Translation = "";
        }
        let data2: Language = { 
            LanguageDescription = "Kurdish";
            LanguageCode = "ku-Arab"; 
            Translation = "";
        }
        
        let dataList= [data; data2]
        let genericList: System.Collections.Generic.List<Language> = dataList.ToList()
        this.View(genericList)


    [<HttpPost>]
    member this.Index(translations: IEnumerable<Language>) =
        this.View(translations)

    // home/about
    member this.About() =
        
        this.ViewData.["Message"] <- "Your application description page."
        this.View()

    // home/contact
    member this.Contact() =
        this.ViewData.["Message"] <- "Your contact page.";
        this.View();

    member this.Error() = this.View()

    member this.SendRequest()