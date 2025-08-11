document.addEventListener("DOMContentLoaded", function () {
  document
    .getElementById("convertForm")
    .addEventListener("submit", async function (e) {
      e.preventDefault();
      const resultDiv = document.getElementById("result");
      const number = document.getElementById("numberInput").value;

      // Reset styles
      resultDiv.classList.remove("error-message");

      try {
        const response = await fetch("/api/convert", {
          method: "POST",
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify({ number }),
        });

        if (!response.ok) {
          const responseText = await response.text();
          try {
            const data = JSON.parse(responseText);
            resultDiv.textContent = data.error || "An error occurred. Please try again.";
          } catch {
            resultDiv.textContent = "An error occurred. Please try again.";
          }
          // Apply error style
          resultDiv.classList.add("error-message");
        } else {
          const data = await response.json();
          resultDiv.textContent = data.result;
        }
      } catch (error) {
        console.error("Error:", error);
        resultDiv.textContent = "An error occurred. Please try again.";
        resultDiv.classList.add("error-message");
      }
    });
});
