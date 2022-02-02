
var totalNumberOfProducts = $("#totalNumber .col-4").length;

var limitOfProductsPerPage = 32;

/* selektori gt() perzgjedh elementet  nga indeksi i percaktuar e me tutje fillon nga 0*/
$("#totalNumber .col-4:gt(" + (limitOfProductsPerPage - 1) + ")").hide(); /* shfaq vetem  8 produktet e para*/ 

var totalNumberOfPages  = Math.round(totalNumberOfProducts / limitOfProductsPerPage +  0.375);

/*  Shton numrin e  butonave  */ 
$(".page-btn").append("<span id='previous-page'>&#8592;</span>");
$(".page-btn").append("<span class='current-page active'>"+ 1 +"</span>");
for (var i = 2; i  <= totalNumberOfPages ; i++) {
    $(".page-btn").append("<span class='current-page'>" + i + "</span>");
}
$(".page-btn").append("<span id='next-page'>&#8594</span>");

/* Ben shfaqjen e produkteve ne varesi te  butonit te  klikuar */
$(".page-btn span.current-page").on("click", function(){
    
    if($(this).hasClass("active")){
        return false;
    }
    else{
        var currentPage = $(this).index();
        
        $(".page-btn span").removeClass("active");
        $(this).addClass("active");

        
        $("#totalNumber .col-4").hide();
        

        var totalNrOfProductShow = limitOfProductsPerPage *  currentPage ;
        

        for(var i = totalNrOfProductShow - limitOfProductsPerPage ; i  < totalNrOfProductShow ; i++){
            $("#totalNumber .col-4:eq(" + i +")").show();
        }
    } 
});

/*  shiqgjetat para dhe mbrapa */

$("#next-page").on("click" ,  function () { 
    var currentPage = $(".page-btn span.active").index();

    if(currentPage  == totalNumberOfPages){
        return false;
    }
    else{
        currentPage++;
        $(".page-btn span").removeClass("active");
        $("#totalNumber .col-4").hide();
        var totalNrOfProductShow = limitOfProductsPerPage *  currentPage ;
        for(var i = totalNrOfProductShow - limitOfProductsPerPage ; i  < totalNrOfProductShow ; i++){
            $("#totalNumber .col-4:eq(" + i +")").show();
        }
        $(".page-btn span.current-page:eq("  + (currentPage - 1) +")").addClass("active");        
    }

});

$("#previous-page").on("click" ,  function () { 
    var currentPage = $(".page-btn span.active").index();
    
    if(currentPage  == 1){
        return  false;
    }
    else{
        currentPage--;
        $(".page-btn span").removeClass("active");
        $("#totalNumber .col-4").hide();
        var totalNrOfProductShow = limitOfProductsPerPage *  currentPage ;
        for(var i = totalNrOfProductShow - limitOfProductsPerPage ; i  < totalNrOfProductShow ; i++){
            $("#totalNumber .col-4:eq(" + i +")").show();
        }
        $(".page-btn span.current-page:eq("  + (currentPage - 1) +")").addClass("active");        
    }
});