/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{js,jsx,ts,tsx}",
  ],
  theme: {
    extend: {},
    screens:{
      mobile: '320px',
      desktop: '740px',
      
    }
  },
  plugins: [],
}
