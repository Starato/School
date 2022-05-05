let fizzbuzz = () => {
    const div = document.getElementById('fb')
    
    for(let i=1; i< 101; i++) {
        const newLine = document.createElement('p')
        for(j=1; j<101; j++) {
            newLine.innerHTML = i + '<br>'           
        }
        if(i % 3 === 0) {
            newLine.innerHTML = (`Fizz ${i}`)
        } 
        if (i % 5 === 0) {
            newLine.innerHTML = (`Buzz ${i}`)
        }
        if (i % 3 ===0 && i % 5 ===0) {
            newLine.innerHTML = (`FizzBuzz ${i}`)
        }
        div.append(newLine)
        
    }
}
fizzbuzz()
    