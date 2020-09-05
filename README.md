# Markdown format

A command-line tool to rewrite quickly written markdown document to be more readable and rich.

## Features

- [ ] replace greek letters written in English/Russian with symbols;
- [ ] support subscript via '_';
- [ ] support superscript via '^';
- [ ] replace sum (and maybe other similar words) with symbols;
- [ ] save original file somewhere instead of overwriting it completely and irreversibly;
- [ ] add support for formatting marked regions (to avoid false positives);
- [ ] add support for formatting text pasted in console window;

## Examples

| Before               | After                                                 |
| -------------------- | ----------------------------------------------------- |
| t_alpha^2x+1         | t<sub>alpha</sub><sup>2x</sup>+1                      |
| t_alpha_1^x^2        | t<sub>alpha<sub>1</sub></sub><sup>x<sup>2</sup></sup> |
| t_(alpha_1+1)^(2x+1) | t<sub>&alpha;<sub>1</sub>+1</sub><sup>2x+1</sup>      |

## Not supported

| Example                                               | Reason                                                                                   |
| ----------------------------------------------------- | ---------------------------------------------------------------------------------------- |
| t<sub>alpha<sup>2</sup></sub><sup>x<sub>1</sub></sup> | parser can't decide whether operation should be applied to base symbol or to last symbol |
