# Learning GitHub Actions

A learning journal for building, testing, packaging, and validating a .NET API with GitHub Actions.

## Commit history and lessons learned

Each entry summarizes the changes and the lesson illustrated by that commit, from oldest to newest.

| Commit | Short description | Lesson learned |
| --- | --- | --- |
| `a5857f7` | Initialized the repository with a README and `.gitignore`. | Start with basic documentation and ignore generated files. |
| `c741179` | Added a demo workflow with event details, checkout, and context output. | Workflows connect triggers, runner jobs, steps, and GitHub context expressions. |
| `aab3198` | Corrected the runner label from `ubuntu-lastest` to `ubuntu-latest`. | Runner labels must be spelled correctly for a job to find a runner. |
| `e191475` | Added a .NET 10 weather API, Swagger UI, and development configuration. | A minimal API provides a real application to build and validate in CI. |
| `80912ff` | Replaced the demo with a learning workflow triggered by pushes to `main` or manual runs. | Configure triggers, read permissions, and environment variables explicitly. |
| `35cfeea` | Added a step that exits with status 1. | A nonzero exit code fails a step and normally skips subsequent steps. |
| `a5c100b` | Replaced exploration steps with checkout, .NET setup, restore, and a Release build. | CI builds need source code, an SDK, and restored dependencies before compilation. |
| `d2d559f` | Listed workspace files before checkout. | A runner workspace does not automatically contain the repository source. |
| `15eddbc` | Listed workspace files after checkout. | Checkout populates the workspace so later steps can access project files. |
| `8bd944a` | Enabled builds for pull requests targeting `main`. | Pull request triggers validate proposed changes before they are merged. |
| `c824447` | Inserted invalid C# into `Program.cs`. | Compilation errors exercise the CI build failure path. |
| `b38f66f` | Removed the invalid C# line. | Fixing the source lets the build proceed past the compilation failure. |
| `09eb778` | Added a solution, xUnit API integration tests, and a workflow test step. | `WebApplicationFactory` can test HTTP responses; tests also need to be built before using `--no-build`. |
| `ef07087` | Changed the build target from the API project to the solution. | Building the solution compiles both the application and its test project. |
| `86fe663` | Added TRX artifact upload and a conditional test failure explanation. | Step outcomes and status conditions let diagnostics run after test failures. |
| `adc91fe` | Corrected `actions/upload_artifact` to `actions/upload-artifact`. | Action references must match the exact repository name. |
| `245a8c1` | Changed the expected forecast count from 5 to 51, introducing a failing assertion. | An incorrect expectation exercises test failure reporting and artifact collection. |
| `6fa72ae` | Restored the expected forecast count to 5. | Assertions must match the API's intended response contract. |
| `f741d30` | Added a packaging job that publishes the API and uploads a commit-named artifact. | `needs` gates packaging on the build job; artifacts preserve files beyond a job. |
| `d62c716` | Fixed indentation in the folded publish command. | YAML block indentation affects whether command lines fold into one shell command. |
| `800df76` | Added shared build settings, an artifact-name output, and a reporting job. | Environment variables reduce duplication; step and job outputs pass metadata between jobs. |
| `56ca814` | Fixed `runs-on` and moved an echo command into a YAML block. | Workflow keys and commands containing a colon need valid YAML syntax. |
| `76d044b` | Added artifact download, required-file checks, and a workflow summary. | Jobs transfer package files through artifacts and can report checks using `GITHUB_STEP_SUMMARY`. |
| `fb9d34d` | Corrected the artifact download directory spelling. | Download destinations must match the paths used by later inspection steps. |
| `4220a0e` | Added a check for a nonexistent `missing.dll`. | A missing required file makes `test -s` fail, exercising package validation. |
| `0a8f63f` | Removed the missing-file check and committed dependency lock files. | Lock files record resolved dependencies for repeatable restores. |
| `46a63a4` | Enabled dependency caching, locked restores, and publishing without another restore. | Lock files support cache keys and locked restores; explicit restore steps avoid redundant work. |
| `63c86d5` | Added Ubuntu and Windows matrix builds, Bash steps, and separate test artifacts. | Matrices validate multiple environments; unique artifact names avoid collisions, and `fail-fast: false` lets other matrix jobs continue. |
| `94ab6b9` | Grouped workflow runs by workflow and Git ref with cancellation enabled. | Concurrency settings cancel older in-progress runs when newer runs supersede them. |
| `7edee32` | Included the matrix OS in the build job's display name. | Descriptive job names make matrix results easier to distinguish. |
| `1a93afd` | Added a smoke test that starts the published API, checks its response, and updates the summary. | Testing the downloaded package verifies runtime behavior; retries handle startup time, and an exit trap cleans up the process and prints logs. |
| `97cc721` | Pinned checkout to a full commit SHA, disabled credential persistence, and removed permissions from the inspection job. | Pin actions to immutable revisions, avoid persisting checkout credentials, and grant jobs only the permissions they need. |
| `644b63f` | Added weekly Dependabot updates for GitHub Actions and instructions for maintaining this journal. | Automate action dependency updates and use repository-specific guidance to keep documentation consistent. |
| `b8b4365` | Added a production environment gate after package validation and updated the learning journal. | Jobs referencing an environment follow its configured protection rules; required reviewers pause execution before the job starts. |
| `9db21b8` | Replaced the approval exercise with Azure login, artifact deployment, live API verification, and cancellation limited to pull requests. | OIDC exchanges GitHub identity tokens for Azure access; deploy validated artifacts and let active main-branch deployments finish. |
| `acbf5c3` | Added a Boolean manual deployment input and allowed explicitly requested deployments from main. | Typed workflow inputs let manual runs choose validation only or deployment while retaining branch restrictions and environment approval. |
| `19bf79e` | Extracted Azure deployment into a reusable workflow with artifact-name and target-environment inputs. | Call reusable workflows at job level with `workflow_call`; pass inputs explicitly and configure environment approval and OIDC permissions across the caller and deployment job. |
