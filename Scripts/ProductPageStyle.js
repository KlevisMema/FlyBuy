    
        var OpenMenuItem = document.getElementById("O");
        var CloseMenuItem = document.getElementById("X");
        var MenuItems = document.getElementById("MenuItems2"); 
        
        MenuItems.style.minHeight = "0px";  

        function MenuToggle (){
            if(MenuItems.style.minHeight == "0px") {
                MenuItems.style.minHeight = "700px";
                CloseMenuItem.style.display = "block";
                OpenMenuItem.style.display = "none";
            }
        }
        
        document.getElementById("X").addEventListener("click" , function(){
            if (MenuItems.style.minHeight == "700px") {
                MenuItems.style.minHeight = "0px";
                CloseMenuItem.style.display = "none";
                OpenMenuItem.style.display = "block";
            }
        });  
        
        window.addEventListener("resize" , ()  =>{
            
            if(window.innerWidth >= 1011)
            {
                CloseMenuItem.style.display = "none";
                OpenMenuItem.style.display = "none";
                MenuItems.style.minHeight = "0px";
                searchBar.style.backgroundColor = "#ffd6d6";
                searchBar.style.width = "0px";
            }
            else if (window.innerWidth < 1011) 
            {
                OpenMenuItem.style.display = "block";
                 searchBar.style.backgroundColor = "#fff";
                 searchBar.style.width = "200px";
            }

            if(MenuItems.style.minHeight == "700px"){
                OpenMenuItem.style.display = "none";
                CloseMenuItem.style.display = "block";   
            }

            if (window.innerWidth >= 1011 && CloseMenuItem.style.display == "block") {
                CloseMenuItem.style.display = "none";
                MenuItems.style.minHeight = "0px";
            }
        })


        /* day  - night mode */

        var nightMode = document.getElementById("night");
        var dayMode = document.getElementById("day");
        nightMode.style.color = "#ff9a8c";
        dayMode.style.color = "#ff523b";

        var Line = document.getElementById("line");
        Line.style.display = "none";
        var LineV2 = document.getElementById("lineV2");
        LineV2.style.boxShadow = "none";
        LineV2.style.background = "#fff";

        
              
        nightMode.onclick = function  () {
            document.body.classList.add("dark-mode");
            nightMode.style.color = "#ff523b";
            dayMode.style.color = "#ff9a8c";
            Line.style.display = "block";
            Line.style.background = "var(--glow-shadow)";
            Line.style.background = "#ff8000";
            LineV2.style.boxShadow = "var(--glow-shadow)";
            LineV2.style.background = "#ff8000";    
        }

        dayMode.onclick = function () {   
            document.body.classList.remove("dark-mode");
            nightMode.style.color = "#ff9a8c";
            dayMode.style.color = "#ff523b";
            Line.style.display = "none";
            Line.style.background = "none";
            LineV2.style.boxShadow = "none";
            LineV2.style.background = "#fff";
        }
        
        /* butoni search */
        var searchBtn = document.getElementById("search");
        var searchBar = document.getElementById("search-bar");
        searchBtn.style.color = "#ff9a8c";
        
        let counterr = 0;

        searchBtn.onclick = function () {
            
            searchBtn.style.color = "#ff523b";
            searchBar.style.backgroundColor = "#fff";
            searchBar.style.width = "200px";

            counterr++;

            if(counterr == 2)
                {
                    searchBar.style.width = "0px";
                    searchBar.style.backgroundColor = "#ffd6d6";
                    searchBtn.style.color = "#ff9a8c";
                }

            if(counterr >= 2 ){
                counterr = 0;
            }     
        }