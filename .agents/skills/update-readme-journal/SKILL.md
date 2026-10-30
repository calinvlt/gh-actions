---
name: update-readme-journal
description: Maintain this repository's README learning journal after commits, matching its existing commit history and lessons learned table. Use when making commits or documenting newly created commits in this repository.
---

# Update the README commit journal

After each commit in this repository, update `README.md` so its learning journal includes that commit.

- Read the existing `Commit history and lessons learned` table before editing. Preserve its columns, wording style, and oldest-to-newest order.
- Compare the table with `git log --reverse --oneline` and inspect missing commits using `git show --stat` and `git show` as needed. Document every missing commit once, including fixes and documentation changes.
- Append a row with the actual abbreviated commit hash in backticks, a concise description of what changed, and the concrete lesson learned. Match the existing format: `| Commit | Short description | Lesson learned |`.
- Base descriptions on the committed changes. Do not invent hashes, changes, test results, or lessons unsupported by the diff. Escape literal pipes inside table cells.
- Preserve existing entries and unrelated README content. Check that the Markdown table remains valid and entries are not duplicated.

A commit's hash is available only after it is created. Update the journal afterward and leave the README change in the working tree for the next authorized commit. Do not automatically create a documentation-only commit, amend history, or push merely to record the entry. This avoids an endless cycle of commits documenting themselves.

When no commit is being created, reconcile existing missing entries if requested; do not add a row for uncommitted work.
