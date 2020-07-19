


var text = "";
let hello = document.createElement('hello');


//var links=document.getElementsByTagName('a')
hrefs = [];


var links = 'https://jobs.illinois.edu/academic-job-board/job-details?jobID=133840&job=college-of-fine-applied-arts-specialized-faculty-industrial-design-open-rank-school-of-art-design-133840'
for (var i = 0; i<links.length; i++)
{   
    hrefs.push(links[i].href);
    console.log(links[i].href);
    //hello.innerHTML = links[i].href;
    hello.innerHTML = '<object type="text/html" data=' + links+ '></object>';

    
    document.body.appendChild(hello);
    var x = document.getElementById("txt");
    setTimeout(function(){ x.value = "2 seconds" }, 2000);

    document.getElementById("#button_apply_to_job").click();
    setTimeout(function(){ x.value = "2 seconds" }, 2000);


    document.getElementsByTagName(hello).innerHTML = ''
    
}   









apply_to_job