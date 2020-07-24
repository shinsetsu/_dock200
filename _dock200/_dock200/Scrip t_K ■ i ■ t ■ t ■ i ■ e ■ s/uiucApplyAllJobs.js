hrefs = []
hello = ''

var links = 'https://jobs.illinois.edu/academic-job-board/job-details?jobID=133840&job=college-of-fine-applied-arts-specialized-faculty-industrial-design-open-rank-school-of-art-design-133840'
for (var i = 0; i < links.length; i++) {
    hrefs.push(links[i].href)
    console.log(links[i].href)

  
    const placeholder = document.createElement('hello')
    hello.innerHTML = '<object type="text/html" data=' + links + '></object>'
    document.getElementById('hello').innerHTML = hello
    confirmApply('https://jobs.illinois.edu/?jobID=242')
}





