using System;

namespace BibleVerseMOTD;

internal static class BibleVerseDatabase
{
    internal readonly struct Verse : IEquatable<Verse>
    {
        internal readonly string Text;
        internal readonly string Reference;

        internal Verse(string text, string reference)
        {
            Text = text;
            Reference = reference;
        }

        public bool Equals(Verse other) =>
            string.Equals(Text, other.Text, StringComparison.Ordinal) &&
            string.Equals(Reference, other.Reference, StringComparison.Ordinal);

        public override bool Equals(object? obj) => obj is Verse other && Equals(other);

        public override int GetHashCode() => HashCode.Combine(Text, Reference);
    }

    internal static readonly Verse[] Verses =
    {
        new("For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.", "John 3:16"),
        new("Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.", "Proverbs 3:5-6"),
        new("I can do all this through him who gives me strength.", "Philippians 4:13"),
        new("The Lord is my shepherd, I lack nothing.", "Psalm 23:1"),
        new("Be strong and courageous. Do not be afraid; do not be discouraged, for the Lord your God will be with you wherever you go.", "Joshua 1:9"),
        new("For I know the plans I have for you, declares the Lord, plans to prosper you and not to harm you, plans to give you hope and a future.", "Jeremiah 29:11"),
        new("Do not be anxious about anything, but in every situation, by prayer and petition, with thanksgiving, present your requests to God.", "Philippians 4:6"),
        new("The Lord is close to the brokenhearted and saves those who are crushed in spirit.", "Psalm 34:18"),
        new("But those who hope in the Lord will renew their strength. They will soar on wings like eagles; they will run and not grow weary, they will walk and not be faint.", "Isaiah 40:31"),
        new("Come to me, all you who are weary and burdened, and I will give you rest.", "Matthew 11:28"),
        new("The Lord your God is with you, the Mighty Warrior who saves. He will take great delight in you; in his love he will no longer rebuke you, but will rejoice over you with singing.", "Zephaniah 3:17"),
        new("And we know that in all things God works for the good of those who love him, who have been called according to his purpose.", "Romans 8:28"),
        new("Have I not commanded you? Be strong and courageous. Do not be afraid; do not be discouraged, for the Lord your God will be with you wherever you go.", "Joshua 1:9"),
        new("Cast all your anxiety on him because he cares for you.", "1 Peter 5:7"),
        new("The name of the Lord is a fortified tower; the righteous run to it and are safe.", "Proverbs 18:10"),
        new("Jesus answered, \"I am the way and the truth and the life. No one comes to the Father except through me.\"", "John 14:6"),
        new("Therefore, if anyone is in Christ, the new creation has come: The old has gone, the new is here!", "2 Corinthians 5:17"),
        new("But the fruit of the Spirit is love, joy, peace, forbearance, kindness, goodness, faithfulness, gentleness and self-control.", "Galatians 5:22-23"),
        new("Love is patient, love is kind. It does not envy, it does not boast, it is not proud.", "1 Corinthians 13:4"),
        new("Above all, love each other deeply, because love covers over a multitude of sins.", "1 Peter 4:8"),
        new("Be kind and compassionate to one another, forgiving each other, just as in Christ God forgave you.", "Ephesians 4:32"),
        new("Do to others as you would have them do to you.", "Luke 6:31"),
        new("Let all that you do be done in love.", "1 Corinthians 16:14"),
        new("In the beginning God created the heavens and the earth.", "Genesis 1:1"),
        new("So God created mankind in his own image, in the image of God he created them; male and female he created them.", "Genesis 1:27"),
        new("The heavens declare the glory of God; the skies proclaim the work of his hands.", "Psalm 19:1"),
        new("Give thanks to the Lord, for he is good; his love endures forever.", "Psalm 107:1"),
        new("This is the day the Lord has made; let us rejoice and be glad in it.", "Psalm 118:24"),
        new("Your word is a lamp for my feet, a light on my path.", "Psalm 119:105"),
        new("Create in me a pure heart, O God, and renew a steadfast spirit within me.", "Psalm 51:10"),
        new("The Lord is my light and my salvation—whom shall I fear? The Lord is the stronghold of my life—of whom shall I be afraid?", "Psalm 27:1"),
        new("Even though I walk through the darkest valley, I will fear no evil, for you are with me; your rod and your staff, they comfort me.", "Psalm 23:4"),
        new("Delight yourself in the Lord, and he will give you the desires of your heart.", "Psalm 37:4"),
        new("Be still, and know that I am God.", "Psalm 46:10"),
        new("If we confess our sins, he is faithful and just and will forgive us our sins and purify us from all unrighteousness.", "1 John 1:9"),
        new("For it is by grace you have been saved, through faith—and this is not from yourselves, it is the gift of God.", "Ephesians 2:8"),
        new("For all have sinned and fall short of the glory of God.", "Romans 3:23"),
        new("For the wages of sin is death, but the gift of God is eternal life in Christ Jesus our Lord.", "Romans 6:23"),
        new("If you declare with your mouth, \"Jesus is Lord,\" and believe in your heart that God raised him from the dead, you will be saved.", "Romans 10:9"),
        new("Therefore, there is now no condemnation for those who are in Christ Jesus.", "Romans 8:1"),
        new("No, in all these things we are more than conquerors through him who loved us.", "Romans 8:37"),
        new("Do not conform to the pattern of this world, but be transformed by the renewing of your mind.", "Romans 12:2"),
        new("And now these three remain: faith, hope and love. But the greatest of these is love.", "1 Corinthians 13:13"),
        new("Rejoice always, pray continually, give thanks in all circumstances; for this is God's will for you in Christ Jesus.", "1 Thessalonians 5:16-18"),
        new("Every good and perfect gift is from above, coming down from the Father of the heavenly lights.", "James 1:17"),
        new("Draw near to God and he will draw near to you.", "James 4:8"),
        new("Humble yourselves before the Lord, and he will lift you up.", "James 4:10"),
        new("Blessed are the peacemakers, for they will be called children of God.", "Matthew 5:9"),
        new("Blessed are the pure in heart, for they will see God.", "Matthew 5:8"),
        new("Let your light shine before others, that they may see your good deeds and glorify your Father in heaven.", "Matthew 5:16"),
        new("Ask and it will be given to you; seek and you will find; knock and the door will be opened to you.", "Matthew 7:7"),
        new("Enter through the narrow gate. For wide is the gate and broad is the road that leads to destruction.", "Matthew 7:13"),
        new("Therefore go and make disciples of all nations, baptizing them in the name of the Father and of the Son and of the Holy Spirit.", "Matthew 28:19"),
        new("Peace I leave with you; my peace I give you. I do not give to you as the world gives. Do not let your hearts be troubled and do not be afraid.", "John 14:27"),
        new("I have told you these things, so that in me you may have peace. In this world you will have trouble. But take heart! I have overcome the world.", "John 16:33"),
        new("Then you will know the truth, and the truth will set you free.", "John 8:32"),
        new("God is love. Whoever lives in love lives in God, and God in them.", "1 John 4:16"),
        new("There is no fear in love. But perfect love drives out fear.", "1 John 4:18"),
        new("He has shown you, O mortal, what is good. And what does the Lord require of you? To act justly and to love mercy and to walk humbly with your God.", "Micah 6:8"),
        new("But the Lord said to Samuel, \"Do not consider his appearance or his height, for I have rejected him. The Lord does not look at the things people look at. People look at the outward appearance, but the Lord looks at the heart.\"", "1 Samuel 16:7"),
        new("The Lord will fight for you; you need only to be still.", "Exodus 14:14"),
        new("Be strong and take heart, all you who hope in the Lord.", "Psalm 31:24"),
        new("Wait for the Lord; be strong and take heart and wait for the Lord.", "Psalm 27:14"),
        new("The Lord bless you and keep you; the Lord make his face shine on you and be gracious to you.", "Numbers 6:24-25"),
    };

    internal static Verse PickRandom(Random random, Verse? avoid = null)
    {
        if (Verses.Length == 0)
        {
            return new("The Lord is good.", "Psalm 100:5");
        }

        if (Verses.Length == 1)
        {
            return Verses[0];
        }

        Verse picked;
        do
        {
            picked = Verses[random.Next(Verses.Length)];
        }
        while (avoid.HasValue && picked.Equals(avoid.Value));

        return picked;
    }
}