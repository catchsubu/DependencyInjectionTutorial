# Contributing to This Repository

Thank you for contributing. This document explains how to contribute, the required coding standards, branch and PR workflows, testing expectations, and other guidelines to keep the project consistent and maintainable.

## Table of Contents

- [Getting Started](#getting-started)
- [Communication & Issues](#communication--issues)
- [Branching Strategy](#branching-strategy)
- [Pull Request Process](#pull-request-process)
- [Commit Message Guidelines](#commit-message-guidelines)
- [Code Style & Formatting](#code-style--formatting)
- [Testing Requirements](#testing-requirements)
- [Code Reviews](#code-reviews)
- [Build and CI](#build-and-ci)
- [Security and Secrets](#security-and-secrets)
- [License and Attribution](#license-and-attribution)
- [Contacts and Maintainers](#contacts-and-maintainers)

## Getting Started

1. Fork the repository and clone your fork locally:

2. Create a feature branch from `main` (or `develop` if used):

3. Follow the coding standards and testing requirements described below.

## Communication & Issues

- Open an Issue for bugs, feature requests, or design discussions before starting large work.
- Use clear titles and include reproduction steps, expected vs actual behavior, and environment details.

## Branching Strategy

- Main branches:
- `main` � stable release branch.
- `develop` � integration branch (optional).
- Branch naming:
- `feature/<short-description>` for new features
- `fix/<short-description>` for bug fixes
- `chore/<short-description>` for maintenance

Keep branches small and focused.

## Pull Request Process

1. Push your branch to your fork and open a Pull Request against `main` (or `develop`).
2. PR Title: concise and descriptive. PR body: motivation, summary, and migration notes.
3. Link related Issues (e.g., `Fixes #123`).
4. Add reviewers and request at least one maintainer review.
5. Address review comments via commits. Avoid force-pushing published branches unless necessary; if you must, explain why.
6. Use the PR checklist before merging.

### PR Checklist

- [ ] Code builds locally and on CI
- [ ] New and existing tests pass
- [ ] Changes follow coding style and naming conventions
- [ ] Documentation or README updated when behavior changes
- [ ] No sensitive data or secrets included

## Commit Message Guidelines

Use a conventional format:

- `type`: `feat`, `fix`, `docs`, `style`, `refactor`, `perf`, `test`, `chore`
- `scope`: optional component or area
- Keep the short description <= 72 characters

Example:

```
fix(auth): handle null token gracefully

Previously, the application would crash if the token was null. This commit ensures that the app handles the null token scenario gracefully, preventing crashes and improving app stability.

Related: #42, #56
```

## Code Style & Formatting

This project enforces consistent formatting. Key points:

- Language: C# targeting .NET Framework 4.7.2
- IDE: Visual Studio 2026 recommended. Check or set:
  - __Tools > Options > Text Editor > C# > Code Style__
  - __Tools > Options > Text Editor > C# > Formatting__
  - __Tools > Options > Environment > Documents__
- Use the included `.editorconfig` (when present) for editor-level rules.
- Naming conventions:
  - PascalCase for public types and members
  - camelCase for private fields and local variables
  - Follow repository conventions for private field prefixes (e.g., `_field`) as specified in `.editorconfig`
- File encoding: UTF-8
- Line endings: LF (configured via `.editorconfig`)

Include unit tests for behavioral changes and document design decisions in the PR.

## Testing Requirements

- Provide unit tests for new behavior. Aim for meaningful coverage on public APIs.
- Test projects should target the same TFM where practical (projects here target .NET Framework 4.7.2).
- Prefer MSTest, NUnit, or xUnit depending on repository conventions. Document chosen framework in README.

## Code Reviews

- Reviewers should focus on correctness, readability, tests, and security.
- Provide actionable feedback and suggest alternatives when applicable.

## Build and CI

- Ensure solution builds in Visual Studio 2026 and via CI.
- Add CI configuration as needed (.yml files) and document in README.

## Security and Secrets

- Never commit secrets (API keys, passwords, certificates).
- Use environment variables or secure vaults in CI.
- If a secret is accidentally committed, rotate credentials immediately and remove history.

## License and Attribution

Ensure contributions include appropriate license and attribution consistent with the repository's LICENSE file.

## Contacts and Maintainers

List maintainers or a team contact and preferred ways to request help (e.g., GitHub Issues, email).

---

If you want `.editorconfig` created or specific style rules added to this document, indicate the preferred rules (e.g., `this.` usage, private field prefix, max line length) and I will add or merge them.
