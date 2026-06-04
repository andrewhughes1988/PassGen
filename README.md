# GitHub Workflow Cheatsheet
### Issue → Branch → PR → Merge (shared-repo / team model)

---

## The Big Picture

```
Issue #42  →  branch  →  commits  →  Pull Request (Fixes #42)  →  review  →  merge  →  issue auto-closes
```

- **Issue** = the ticket (bug, feature request, task) — categorized by **labels** (`bug`, `enhancement`)
- **Branch** = isolated workspace for the change
- **PR** = proposal to merge the branch, where review happens
- **Merge** = change lands in `main`; linked issue closes

> You have **write access** to a company repo → **branch directly, don't fork.**
> Fork only when you have read-only access or it's an open-source contribution.

---

## 1. Create an Issue

Repo → **Issues** tab → **New issue**
- Clear title: *"Login fails on Safari 17"* (not "bug")
- Description: steps to reproduce, expected vs. actual, environment
- Set **labels**, **assignee** (assign yourself), optional **milestone** / **project**
- Use Markdown: code blocks, `- [ ]` task lists, drag-and-drop screenshots

---

## 2. Create a Branch (tied to the issue)

**Best: from the issue itself**
Issue page → right sidebar → **Development → Create a branch**
- Auto-names it (`42-login-fails-on-safari`) and **auto-links** to the issue
- Copy the `git fetch` / `git checkout` commands it gives you

**Or from the command line:**
```bash
git checkout main
git pull                          # get latest
git checkout -b 42-safari-login   # branch off main
```

---

## 3. Do the Work

```bash
git add .
git commit -m "Fix Safari login redirect"
git push origin 42-safari-login   # push branch to GitHub
```
Push more commits to the same branch anytime to update the PR.

---

## 4. Open the Pull Request

GitHub shows **"Compare & pull request"** after you push.
- **Base** = where changes go (usually `main`); **Compare** = your branch
- In the description, link the issue:
  ```
  Fixes #42
  ```
  Keywords: `Fixes` / `Closes` / `Resolves` (+ `fixed`, `closed`, etc.)
  → auto-closes the issue on merge **(only when targeting the default branch)**
  → use plain `#42` to reference without closing
- Add reviewers; open as a **Draft PR** if not ready

---

## 5. Review

- Reviewers comment, **request changes**, or **approve**
- Address feedback by pushing more commits to the same branch
- Resolve any **merge conflicts** (same lines changed in both branches)
- **Branch protection** on `main` may require approvals + passing checks before merge — this is normal

---

## 6. Merge

Pick a merge strategy:
| Option | Result |
|---|---|
| **Merge commit** | Keeps every commit + a merge commit (full history) |
| **Squash and merge** | Combines all commits into one (clean history) — most common |
| **Rebase and merge** | Replays commits onto base, no merge commit |

After merge:
- Linked issue **closes automatically**
- **Delete the branch** (GitHub offers a button)
```bash
git checkout main
git pull                          # bring the merge local
git branch -d 42-safari-login     # delete local branch
```

---

## Quick Git Command Reference

```bash
git clone <url>              # one-time: copy repo locally
git checkout main            # switch to main
git pull                     # download latest changes
git checkout -b <branch>     # create + switch to new branch
git add .                    # stage all changes
git commit -m "message"      # save a snapshot
git push origin <branch>     # upload branch to GitHub
git status                   # see what's changed
git log --oneline            # compact history
```

---

## Linking Cheatsheet

| Action | How |
|---|---|
| Auto-close issue on merge | `Fixes #42` in PR description (PR must target default branch) |
| Reference without closing | `#42` plain |
| Link branch ↔ issue automatically | Create branch from the issue's sidebar |
| Mark a feature request | Label it `enhancement` |
| Work-in-progress PR | Open as **Draft** |

---

*Mental model: issue = the ticket · branch = the work · PR = the review · merge = it ships.*
