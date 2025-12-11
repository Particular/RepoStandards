# **Polling** RFC for updating select enforced coding standards

## How to interact with this RFC

<!-- Include a definition of the available emojis that others can use to easily indicate their opinion

 Emoji reactions allowed on GitHub comments are :+1:, :-1:, :smile:, :tada: , :heart:,  :rocket:, :eyes

 If you want to allow other emojis, then they will need to be in comments.

 Once published, be sure to click each of the emojis so that staff understand the array of choices and aren't required to be the first to select one of the options.
-->

Please respond with one the following emoji for each coding standard in dispute: 

- :+1: Change the restriction on explicitly marking methods/fields as private to `Prefer accessibility modifiers except for public interface members`
- :-1: Leave the explicitly marking methods/fields as private restriction as is
- :heart: Remove the strict enforcement of brackets around single line if statements
- :rocket: Leave the strict enforcement of brackets around single line if statements

Optionally, leave a comment explaining your vote.

## Context of work done

I am proposing to modify the currently enforced coding standards in two areas:

- Currently the coding standards disallow explicitly marking class methods/fields as private, since private is the default modifier in C#.
- Currently the coding standards enforce having brackets around if statement blocks, even if the block logic is a single line.

### Explicitly marking methods/fields as private

The rule being enforced here is https://learn.microsoft.com/en-gb/dotnet/fundamentals/code-analysis/style-rules/ide0040, with the option currently set to `never`. This option is treated as a warning in the IDE, but upgrades to an error on the CI build. The rule actually deals with setting accessibility modifiers where the modifier is the default value for the context; since private is generally the default value in most context, I have referred to this suggested change using 'private'

Based on the assumption that, similar to me, other engineers have experienced many years of coding with explicitly stated access modifiers, even when that modifier is the default behaviour, since this is the default setting of rule IDE0040
and in order to align with principles and practices [Meet people where they are](https://github.com/Particular/Strategy/blob/master/org-philosophy/organizational-philosophy.md#practice-meet-people-where-they-are) 
I have observed that reading code without explicity stated access modifiers causes a cognitive roadblock and disrupts my ability to concentrate on the code flow, as I need to consciously determine the accessbility of the method/field in question
which leads me to the conclusion that this coding standard causes loss of productivity, which is admittedly small for each occurence but builds up over time
therefore I recommend changing this coding standard to the default value of `Prefer accessibility modifiers except for public interface members`

### Requiring brackets around single line if statement blocks

The rule being enforced here is https://learn.microsoft.com/en-gb/dotnet/fundamentals/code-analysis/style-rules/ide0011, with the option currently set to `true`. This option is treated as an error both in the IDE and on the CI build.

Based on assumptions that most engineers code on screens in landscape mode, and therefore have more horizontal real-estate than vertical
and in order to align with principles and practices [Meet people where they are](https://github.com/Particular/Strategy/blob/master/org-philosophy/organizational-philosophy.md#practice-meet-people-where-they-are)
I have observed that code is more readable if certain constructs, such as simple if statements, are tightly related, visually
which leads me to the conclusion that requiring brackets around a simple single line if statement unnecessarily 'bloats' the visual code by increasing visible vertical whitespace. This is especially annoying for "quick exit" constructs, where there is a validity check at the top of a method with `if (!valid) return;` as a simple visual indication of when the rest of the contents of the method are not relevant.
therefore I recommend removing this rule. I do not recommend enforcing IDE0011 to `false`, since there can be complex, and/or long, single line statements which would be made clearer visually by having block brackets around them.

## Additional information

These changes were first discussed at the Prague 2025 conference and the result of that discussion was this RFC.
