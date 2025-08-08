document.getElementById('converterForm').addEventListener('submit', function(e) {
    e.preventDefault();
    const number = document.getElementById('numberInput').value;
    fetch('/api/convert', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({ number: number })
    })
    .then(response => response.json())
    .then(data => {
        document.getElementById('result').textContent = data.result;
    })
    .catch((error) => {
        console.error('Error:', error);
        document.getElementById('result').textContent = 'An error occurred. Please try again.';
    });
});
