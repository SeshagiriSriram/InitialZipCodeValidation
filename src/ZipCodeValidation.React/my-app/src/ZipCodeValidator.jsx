import { useState } from "react";
function ZipCodeValidator() {
  const [form, setForm] = useState({ zipCode: "", locality: "", state: "", country: "" });
  const [result, setResult] = useState(null);
  const handleChange = (e) => setForm({ ...form, [e.target.name]: e.target.value });
  const validate = async () => {
    const response = await fetch("http://localhost:5149/api/zipcode/validate", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(form),
    });

 if (response.ok) {
    const text = await response.text();
    if (text) {
      setResult(JSON.parse(text));
    } else {
      setResult({ isValid: false, error: "Empty response from server" });
    }
  } else {
    setResult({ isValid: false, error: `HTTP ${response.status}` });
  }
  };
  return (
    <div>
      <input name="zipCode" onChange={handleChange} placeholder="Zip Code" />
      <input name="locality" onChange={handleChange} placeholder="Locality" />
      <input name="state" onChange={handleChange} placeholder="State" />
      <input name="country" onChange={handleChange} placeholder="Country" />
      <button onClick={validate}>Validate</button>
      {result && (
        <div>
          {result.isValid ? "✅ Valid" : `❌ Error: ${result.error}`}
        </div>
      )}
    </div>
  );
}
export default ZipCodeValidator;
