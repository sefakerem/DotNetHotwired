/** @type {import('tailwindcss').Config} */
module.exports = {
    content: ['../Pages/**/*.cshtml', '../Areas/**/*.cshtml'],
  theme: {
    extend: {},
  },
    plugins: [
        require('@tailwindcss/forms')
    ],
}
