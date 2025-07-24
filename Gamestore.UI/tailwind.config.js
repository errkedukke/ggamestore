/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./src/**/*.{html,ts}"],
  theme: {
    extend: {},
  },
  plugins: [
    function ({ addUtilities }) {
      addUtilities(
        {
          ".scrollbar-hide": {
            /* Firefox */
            "scrollbar-width": "none",
            /* Safari and Chrome */
            "-ms-overflow-style": "none", // IE 10+
            "&::-webkit-scrollbar": {
              display: "none",
            },
          },
        },
        ["responsive"]
      );
    },
  ],
};
