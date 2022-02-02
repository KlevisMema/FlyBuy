    
        var OpenMenuItem = document.getElementById("O");
        var  CloseMenuItem = document.getElementById("X");
        var MenuItems = document.getElementById("MenuItems"); 
        MenuItems.style.maxHeight = "0px";       

        function MenuToggle (){
            if(MenuItems.style.maxHeight == "0px") {
                MenuItems.style.maxHeight = "100%";
                CloseMenuItem.style.display = "block";
                OpenMenuItem.style.display = "none";
            }
        }
        
        document.getElementById("X").addEventListener("click" , function(){
            if (MenuItems.style.maxHeight == "100%") {
                MenuItems.style.maxHeight = "0px";
                CloseMenuItem.style.display = "none";
                OpenMenuItem.style.display = "block";
            }
        });  
        
        window.addEventListener("resize" , ()  =>{
            
            if(window.innerWidth >= 1011)
            {
                CloseMenuItem.style.display = "none";
                OpenMenuItem.style.display = "none";
            }
            else if (window.innerWidth < 1011) 
            {
                    OpenMenuItem.style.display = "block";
            }

            if(MenuItems.style.maxHeight == "100%"){
                OpenMenuItem.style.display = "none";
                CloseMenuItem.style.display = "block";   
            }

            if (window.innerWidth >= 1011 && CloseMenuItem.style.display == "block") {
                CloseMenuItem.style.display = "none";
            }
        })


        /* day  - night mode */

        var nightMode = document.getElementById("night");
        var dayMode = document.getElementById("day");
        dayMode.style.color = "#ff523b";

        let OfferEffect = document.getElementById("offer");
        let OfferPosition = document.getElementById("col-2-position");
        let OfferPositionV2 = document.getElementById("col-2-position-2");
        let OfferPositionTittle = document.getElementById("OfferTittle");

        var Line = document.getElementById("line");
        Line.style.display = "none";
        var LineV2 = document.getElementById("lineV2");
        LineV2.style.boxShadow = "none";
        LineV2.style.background = "#fff";
       
        nightMode.onclick = function  () {
            document.body.classList.add("dark-mode");
            OfferEffect.style.background = "linear-gradient(var(--primary-color), #ffd6d6 ,  var(--primary-color)";
            OfferPosition.style.marginTop = "-60px";
            OfferPositionV2.style.marginTop = "-120px";
            OfferPositionTittle.style.display = "none";
            nightMode.style.color = "#ff523b";
            dayMode.style.color = "#fff";
            Line.style.display = "block";
            Line.style.background = "var(--glow-shadow)";
            Line.style.background = "#ff8000";
            LineV2.style.boxShadow = "var(--glow-shadow)";
            LineV2.style.background = "#ff8000";
        }

        dayMode.onclick = function () {
            document.body.classList.remove("dark-mode");
            OfferEffect.style.background = "linear-gradient(var(--primary-color), #ffd6d6";
            OfferPosition.style.marginTop = "0px";
            OfferPositionV2.style.marginTop = "0px";
            OfferPositionTittle.style.display = "block";
            nightMode.style.color = "#fff";
            dayMode.style.color = "#ff523b";
            Line.style.display = "none";
            Line.style.background = "none";
            LineV2.style.boxShadow = "none";
            LineV2.style.background = "#fff";
        }