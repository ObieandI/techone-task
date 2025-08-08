document.addEventListener("DOMContentLoaded", function () {
  document
    .getElementById("convertForm")
    .addEventListener("submit", async function (e) {
      e.preventDefault();
      const number = document.getElementById("numberInput").value;
      try {
        const response = await fetch("/api/convert", {
          method: "POST",
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify({ number }),
        });
        if (!response.ok) {
          throw new Error(`HTTP error! status: ${response.status}`);
        }
        const data = await response.json();
        document.getElementById("result").textContent = data.result;
      } catch (error) {
        console.error("Error:", error);
        document.getElementById("result").textContent =
          "An error occurred. Please try again.";
      }
    });
});
