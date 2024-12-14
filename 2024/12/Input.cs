namespace AdventOfCode._12
{
    public static class Input
    {
        public static string GetSample1()
        {
            return @"AAAA
BBCD
BBCC
EEEC";
        }

        public static string GetSample2()
        {
            return @"OOOOO
OXOXO
OOOOO
OXOXO
OOOOO";
        }

        public static string GetSample3()
        {
            return @"RRRRIICCFF
RRRRIICCCF
VVRRRCCFFF
VVRCCCJFFF
VVVVCJJCFE
VVIVCCJJEE
VVIIICJJEE
MIIIIIJJEE
MIIISIJEEE
MMMISSJEEE";
        }

        public static string GetInput()
        {
            return @"QQQQQQQQQIIIIIIIIIISSSSSSSSSSYYYYNNNNNNNNNNNNNNKKKKKLLLLLLRRRRRRRRRRDDDDDDDDDQQQNNNNNNNNNNNNNNNNNNNNTTTTKKKKKKKCCCCCCGGGGGGGGEEOOOOOOOOOOOOO
QQQQQQQQQQIIIIIIIIISSSSSSSSSSSYYNNNNNNNNNNNNNNKKLLLLLLLLLLRRRRRRRDRDDDDDDDDDQQQNNNNNNNKKKKKKKKNKTNNNTTKKKKKKKKKKKCCCCGGGGGGGGGEOOOOOOOOOOOOO
QQQQQQQQQQQIQQQIIISSSSSSSSSSSSYNNNNNNNNNNNNNNKKLLLLLLLLLLLLRRRRRDDDDDDDDDDDDGQQQQQNNNNKKKKKDKKNKTTTTTTTKKKKKKTKKKKCCCGGGGGGGGEEOOOOOOOOOOOOO
QQQQQQQQQQQQQQIIIISSSSSSSSSSSSSNNNNNNNNNNKNXNKKKKAALLLLLLLRRRRRRRRDDDDDDDDDDDDQQQNNNNNKKKKKKKKKKKTTTTTKKKKKKKKKKKKCCCGGGGGGGGEEEOOOOOOOOOOOO
QQQQQQQQQQQQQQQIIISSSSSSSSSSSSSDDNNNNNNNNNNXNKKKKAALLRLLLRRRRRRLRDDDDDDDDDDDDQQQQQNNNNKKKKKKKKKKTTTTTXXXKKRKKKKKCCCCCGGGGGGGGEEOOOOOOOOOOOOX
QQQQQQQQQQQQQQQQIISSSSSSSSSSSSSDNNNNNNNNNNNNKKKAAAALLRRLRRRRRRRRRDDDDDDDDDDNDQQQQQQQNKKKKKKKKKKNNTTXTXXXKKRRKKCCCCCCCGGGGGGGOOOOOOOOOOOSSSOX
QQQQQQQQEEQQQQQIIISSSSSSSSSSSSSSBNNOONQQNNNQQKAAAAAVLRRRRRRRRRRRRDDDDDDDDDDNDQQQQQQQNNKKKKKKKKKKKXXXXXXXKKRRRCCCCCCCCGKKGGGOOOOOOOSOOWSSSSSS
QQQQQQQEEEEIIIIIISSSSSSSSSSOSSSSBQQOOQQQNNQQQQAAAAAVARRRRRRRRRRRRRRRRDDDDDDNDDQQQQQQQNKKKKKKKKKKAXAAXXXKKKRRRRCCCKKKGGKKKGKKKKKOOOSSSSSSSSSS
QQQQQQEEEEIIIIIIISSZZZSZSSOOSVSSSQQQQQQQQQQQQQQAAAAAALRLRRRRRRRRRRRRJDDDDDDDDQQQQQQQQKKKKKKKKKKKAAAAAXXXKRRRRRCCCCKKKKKKKKKKKKKKOOSSSSSSSSSS
QQQQQBBEEEEIEIEEESSJZZZZSSSMMVSBBQQQQQQQQQQQQQAAAAAAALLLLRRRRRRRRRRRRDDDDDDDDQQQQQQQQKKKKKKKKKKAAAAAAXXXKRSRRRCCCEEKKGKKKKKKKKKKOKSSSSSSSSSS
QQQQQBBEEEEEEEEEEEJJZZZZZZMMMMMBBBBQQQQQQQQQQQQQAAAAAAALRRRRRRRYRRRNRRDDYDDQQQQQQQQQQKKKKKKKKKAAVVVAXXXWWWWWRCCEEEEFGGKKKKKKKKKKKKSSSSSSSSSS
QQQQQBBBBEEEEEEEEJJJZZZZBMMMMMMBBQQQQQQQQQQQQQQAAAAAAAALLLRRRRRYYRRRRYYYYYDQFFQQQQQQQKKKKKKKKKAAAAVXXXWWWWWWRCCCEEEGGGKKKKKKKKKKKKSSSSSSSSSS
QQQQBBBBEEEEEEEEEJZZZZZZMMMMMMMMQQQQQQQQQQQQQQQAAAAAUUULLLRRRYYYYRRRRYYYYYDFFFFFQQOOOKAAKKKKKAAVVVVVWWWWWWWWRCCCCCEGGGKKKKKKKKKKKKKSSSSSSSSS
BBBBBBBEEEEEEEEEEJJJZZZMMMMMMMMMQQQQQQQMMMMMQQQAAAAAUUULLLRRRYYYYYYYYYYYYFFFFFFFQQOOOOAAKAKKAAVVVVVVVWWNWWWWWCCCCGGGGSKBKKKKKKKKKKSSSSSSSSSS
BBBBBBBEEEEEEEEEEEENNZZMMMMMMMMMMQQQZMMMMMMMMMQQGUUUUUULLURRYYYYYYQYYYYYYFFFFFFFFFOOAAAAAAAAAAAVVVVVVWWWWWWWWWCGGGGGGBBBBKKKKKKKKKSSSSSSSSSS
BBBBBBBBEDDEEEEEEEEGNNZMMMMMMMMMQQQQZMMMMMMMMGGGGUUUUUUUUUYYYYYYYYQQRYYYYFFFFFFFFFFFUAAAAAAAAVVVVVVVCWWWWWWWWWCGPGGGGBBBBBBBBKKKKKKKSSSSSSSS
BBBBBPBBEEEEEEEEEEENNNMMMMMMMMMMMQQQMMMMMMMMMMUUUUUUUUUUUYYYYYYYYYQQQQQQYFWWFFFFWFFUUAAAAAAAAVVVVVVVWIWWWWWWWLGGGGGGGGBBBBBBBKKKKKKKKSSSSSSS
BBBBBPBBEEEEEEEEENNNNNMMMMMMMMMMMQLMMMMMMMMMMMUUUUUUUUUUUYYYYYYYYYYYQQWWWWYWWWFWWUUUUUAAAVAAAVVVVVVVWWWWWWWWWWFFGGGGGGGBBBBBBBKKKKKKKSSSSSSS
BBBBBPBBBBEEEEEEENNNNNNNNMMMMMMMMQMMMMMMMMMMMMUUUUUUUUUUUUYYYYYYYYYYQWWWWWWWWWWWWUUUUUAAVVAAAVVVVVVVVVWWWWWWGGGGGGGGGGGBBBBBBBKKKKKKKKSSSSSS
BBBBBPBPPBEEEEEEENNNNNNNAMMMMMMMMMMMMMMMMMMMMMUUUUUUUUUUUUUUYYYYYYYYWWWWWWWWWWWWWWUZZUAAVVVVVVVVVVVVVVVVVWWWLGGGGGGGGBBBBBBBBBBKKKKKKUSSSSSS
BBBBPPPPPBEEEBWWENNNNNNNNNNMMMMMGMGGMMMMMMMMMMUUUUUUUUUUUUYYYYYYYYYYWWWWWWWWWWWWWWWWAAAAVVVVVVVVVVVVVVVVVVVWLGGGGGGGGBBBBBBBBBBBBKDDDUUSSSSS
BBBBPPPPPPPEBBWWWNNWNNNNNNYMMMMMGGGGMMMMMMMMMMMUUUUUUUUUUUYYYYYYYYYYWWWWWWWWWWWWWWWWAAAAAAVAAVVVVVVVVVVVVVVLLGGGGGGGGBBBBBBBBBBVVDDDDUDMSSSS
BBBPPPPPPBBBBWWWWWWWWNNNNNYMMMGGGGGGMMMMMMMMMMMUUUUUUUUUUUUYYYYYYYYWWWWWWWWWWWWWWAAAAAAAAAAAAVVVVVVVVVVVVVVLLLGGGGGGGBBBBBBBBBBVVDDDDDDSSZZS
BBPPPPPPPWWWWWWWWWWWWNNNNYYYMMMEEGEEJMMMMMMMMMMUUUUUUUUUXXYYYYYYYYYWWWWWWWWWWWWWAAAAAAAAAAAAAAVVVVVVVVVVVVVLLLGGGGGGGBBBBBBBBBBYYNDDDDDDDDZZ
PPPPPPPPPWWWWWWWWWWWWLNLEEYYMOEEEEEEEEMMMMMMUUUUUUUUUUUUUXXYYYYYYWWWWWWWWWWWWWUWAAAAAAAAAAAAVVVVVVVVVVVVVVVLGGGKBGGOGGGGBBBBBBBYYYKDDDDDDDDD
PPPPPPPPPPWWWWWWWWWWLLLLLEYEOOEEEEEEEEOMMMMMUUUUUUUUUUKKUUXYYYYYYWWWWWWWWWWWWWWWAAAAAAAAAAAAAVVVVVVVVVVVVVVVVVGKGGGOGGGBBBBBBBBYMYYDDDDDDDDD
RPPGPPPPPPWWWWWWWWWWWWLLLEEEEEEEEEEEEMMMMMMMUUUUUUUUUUUUUUUURYWWWWWRWWWWWWWOWWWAAAAAAAAAAAAAAVVVVVVVVVVVVVVVVKKKKGOOGGGBBBBBBTYYYYYYDDDDDDDD
RRRPPPPPPPWWWWWWWWWWWLLLLLEEEEEEEEEEEMEEMMUUUUUUUURRUUUUUCCURRRRRRRRWWOOOOOOOOAAAAAAAAAAAAAAAVVVVVVVVVVVVVVVKKOEEEOOGGGBBBGYYYYYYYYYYDYDDDDD
RRRRPPPPPPWWWWWWWWWWLLLLLLEEEEEEEEEEEMEEUUUUUUUUUUURUUUXXXCCRRRRRRRRWOOOOOOOOOAAAAAAAAAAAAAAAAVVVVVVVVVVVOOOKOOOOOOOGOGGGGGGGYYYYYYYYYYDDDDD
RRRRRRPPMMWWWWWWWWWWWWLLLLELJEEEEEEEEEEEEUUUUUUUUUURUXXXXXXCRRRRRRROOOOOOOOOOAAAAAAAAAAAAAAAAAAMVVVVVVVVVOOOOOOOOOOOOOOGGGGSYYYYYYYYYYYYYDDD
RCCCCCPPPMWWWWWWWWWWWWLLLLLLJJJJEEEEUUUUUUUUUUUUUUWXXXXXOXXXRRRRRRRRROOOOOOOOAAAAAAAAAAAAAAAAAMMVVVVVVVVVOOOHOOOOOOOOGGGGGGGYYXYYYYYYYYMMDDD
RRCCCCCMMMWWWWWSWRWWWWLLLLLLJJUJEEEEEEUUUUUUUUUXXXWXXXXXXXXXRRRRRRRROOOOOOOOOAAAAAAAAAAAAAAAAAMMMMVVVVVVVVOOOOOOOOOOOGHHGGGGTYYYYYYYYYYYMDII
RCCCCCCCCQWWWWSSWRWWWWLLLLLLLJJJEEEEEEPUUUUUUUUUXXXXXXXXXXXFRRRRRRRRROOOOOOOOAAAAAAAAAAAAAAAAMMMMMVVVVVVVVOOOOOOOOOOOHHHHGGGGYHYYYYYYMMMMDII
RCCCCCCCQQQQLSSSSSSSWLLLLLLLLJJJEOOOOOPPUPUUUUUUXXXXXXXXXXPRRRRRRRRRRROOOOOOOAAAAARAAAAARAAAAMMMMMMVXVVVVVOOOOOOOOOOOOOOHHHGGHYYYYYYYYYMMMII
RCCCCCCQQQQQSSSSSSSLLLLLLLLLLLJEEOOOOOPPPPPPUUUUXXXOXXXXXXXRRRRRRRRRRROOOOOOOAAVAARARRAORAAMMMMMMMVVXVVXXXOOOOOOOOOOOOOOHHHHHHYYYYYYYYIMIIII
CCCCCCCCQQQQSSSSSSSLLLLLLLLLLLJEEOOOOOPPPPPPPUUUXXXUXXXXXXVRRRRRRRRRRRRAAAOOOARRRRRRRRRRRAMMMMMMMMMMXXXXXXOOOOOOPPOOOOOOHHHHHHHHYYYHYIIIIIII
CCCCCCCCQQQQSSSSJLLLLLLLLLLLLLLLEOOOOOPPPPPPPUUUUUUUXXXXXXVVVRRRRRRRRRRAARAOORRRRRRRRRRRRRRMMMMMMMMMXXXXXXXXOOPPPPPOOOOHHHHHHHHHHYYHIIIIIIII
CMCCCCCCQQQQQSSPPQOLCOOLLLLLLLLLLOOOOOPPPPPPPPPUUUUUUXXXVVVVVRRRRRRRRRRAAAAAORRRRRRRRRRRRRGGGMMMMMMXXOIIXXXPPPPPPPPROOHHHHHHHHHHHYHHHIIIIIHH
CCCCCCCCQQQQQQQPOQOOOOOOLLLLLLLLLOOOOOPPPPPPPPPUUUUUVVVVVVVVVVVRRRRRAAAAAAAAARRRRRRRRRRRRRGGGGMMQMMOOOIIIIXPPPPPPPRRRRPHHHHHHHHHHYHHHIHHHHHH
CCCCCCCCCFQQQQPPOOOOOOOOOLLLLLLKKOOOOOPPPPPPPPZZZUUFFFVVVVVVVVRRRRRRAAAAAAAAHHRRRRRRRRRRRMGGGGQQQMOOOOOIIIPPPPPPPPPPPPPHHHHHHHHHHHHHHHHHHHHH
PCCCCCPCPQQQPQQPPPOOOOOOOLLLLLLKKOOOOOLPPPPPPZZZZZZFFFFFVVVVVVVRRRRAAAAAAAAAHHRRRRRRRRRRRRGGGGOOOOOOOOOIIPPPPPPPPPPPPPPPPHHHHHHHHHHHHHHHHHHH
PCCCCPPCPPPQPPPPPPOOOOOOLLLLKLKKKKLLLLLPPPPPZZZZFFFFFFFVVVVVVVVVRNAAAAAAAAAAARRRRRRRRRRRRGGGGGGYOOOOOOOIIIPPPPPPPPPPPPPPEHHHHHHHUHHHHHHHUHHH
PPCCCPPPPPPPPPSPPPPOOOOOLLLKKLLKKLLLLLLPPPPUUUUFFFFFFFFFFVIIVVVVRNAAAAAAAAAAARRRRRRRRRRRRTTTGGGOOOOOOOOOIIPUPPPPPPPPPPPPPPHHHHHHUHHHHHHHUUUU
PPCCCPPPPPPPPSSSSSSOQOOKLLLKKLLKKKULLUUUUUUUUUUFFFFFRRFRIIIIVVVVVAAAAAAAAAAAARRRRRRRRRRRRTTTTGGFFFOIIIIIIIIPPPPPPPPPPHHHHHHHHHHHUUHHHHHUUUUU
PPPPPPPPPPPPPSSSSSSSQKKKKKLKKKKKUKULLUUUUUUUUUUUFFFFRRRRRIIIIIVVVVAAAAAAAAAAARRRRRRRRRRRRTTTTGFFFFIIIIIIIIIPPPPPPPPHHHHHHHHHHHHHULUUHUUUUUUU
PPPPPPPPPTTPPPSSSSSSQKBKKKKKKKKKUUUUUUUUUUUUUUVUFFRRRRRRIIIIIIIIIAAAAAAAAAAAARRRRRRRRRRRRRRTTTFFFFFFFFIIIIIPPPPPPPPDHHHHHHHHHHHHUUUUHUUUUUUU
PCPPPPPPPTTTPTWSSSSSSSKKKKKKKKKKKUUUUUUUUUUUVVVFFFRRRRRRIIIIIIIIBBAAAAAAAAAAARRRRRRRRRRRRRRTFFFFFFFFFFIIIPIIPPPPDDDDHHHHHHHHHHHIUUUUUUUUUUUU
PCPPPPTTTTTTTTWWWWWSSKKKKKKKKKKKKUUUUUUUUUUVVVVVPVRRRRRIIIIIIIIIBBAAAAAAAARRRRRRRRRRRRRRRFFFFFFFFFFFFFIPPPIIGGGPGDDSHHHHHHHHHHIIUUUUUUUUUUUU
CCPPPPTTTTTTTTTTWWSSSSKKKKKKKKKKKUUUUUUUUUUVVVVVVVQRKKRKIIIIIIIIBBBAAAAARRRRRRRRRRRRRRRRFFFFFFFFFFFFFPPPPPIGGGGGGGDDDHHHHHHHHHIIUUUUUUUUUUUU
CCPPTTTTTTTTTTTWWWWWWWWKKKKZKKKUUUUUUUUUUUUVVVVVVVVKKKKKIIIIHHIIBBBBAAATTRRRRRRRRRRRRRRRFFSFFFFFFFFFFPPPPPPGGGGGGGDDDHHHHHHRHIIIIIUUUUUUUUUU
CCCPTTTTTTTTGGWWWWWWWAAAAZZZKKUUUUUUUUUUUUUVVVVVVVVKKKKKIIIIHHHIIBUBBBTTTTRRRRRRRRRRRRRRRFFHFFFFFFFFFPPPPPPGGGGPGGDHHHHHHHHRIIIIIIIUUUUUUUUU
CCCCTTTTTTTGGGGGZZZZAAAAAZZZZKUUUUUUUUUUUUUVIVWVVVKKKKKKIIIIIHHUUUUBBTTTTTRRORRRRRRRRRRRRHHHFFFFFFFFPPPPPPPPGPPPGGHHHHHHHHRRIIIIIIUUUUUUUUUU
CCCMMTTTTGTTTGGHGZZRRAAAAZZZZUUUUUUUUIIUUUVVVWWVKKKKKKKKIIIIIUUUUUUBTTTTTTRROOORRRRRRRRRRHHHFFFFFFFFPPPPPPPPPPPPGGHHHHGGGGRRRRRRIUUUUUUUUUUU
DCMMTTTTGGGGGGGGGGZZAAAAAZZZZZUUUUUUUIIIIIVVVVVKKKKKKKKKIKKIIDUUUUUUTTTTTTTROOOORRRRRRRRRRNNFFFFKFFPPPPPPPPPPPPPPGGHGGGGLLLRRRRIIUUUUUUUUUUU
DDDMTTTTDGGGGGGGGGZZZZZAZZZZZZUUUUUUIIIIIIVVVVKKKKPKKKTKKKKKUUUUUUUUTTTTTQTOOOOOOORRRRRRRNNNNNFFKKKPPPPPPPPPPPPPPGGGGGGGLLLLRLLLLLUUUUUUUUUU
DDDDTTGGGGGGGGGGGXGGZZZVVVVVVVVUUUIIIIIIIIXXJJJKKPPPKKTKKKKKJKUUUUUUTUTTTQQOOOOOGGRRRRNNNNNNNNKFFKKPPPPPPPPPPPPPGGGGGGNLLLLLRLLLLLUUUUUDDUUU
DDDTTGGGGGGGGGGGGGGGZZZVVVVVVVVXIUIIIIIIIIXJJJJKKPPFTTTTKKKKJKUUUUUUTUUUEOOOOOOOOIRRRRRNNNNNNNKKKKKKKKPPPPPPPPPPNNGGGNNNLLLLLLLLLLUUUUDDDBUU
DDDDTTGGGGGGGGGGGGGGZZZVVVVVVVVIIIIIIIJJJJJJFJJJKTTTTTTTKKKKJKUUUUUUUUUEEOOOOOOOOIIRYYRNNNNNNNKKKKNKKKPPPPPPPPNNNGGGGNNNNNLLLLLLLLPDDUDDDBBU
DDDDDTTGGWGGGGGGGGGGKZKVVVVVVVVVVVIIIIIJJJJJJJJJJTTTTTTTTKKKKKUUUUUAAUUUOOOOOOOIOIIYYYYNNNNNNNKKKKNKKKNPPNNNNNNNCCCGGGNNNNNLLLLLLPPDDDDDDDDD
DDDDDDDGGGGGGGGQKKKZKZZVVVVVVVVVVVIIIIIIJJJJJJJJJTTTTTTTTTTKKKUUAUAAAAUAAOOOOOIIIIIIIYYIYIINNNKKKNNNNNNPPOOOOOOOOOCCNNNNNNLLLLLLLLPPDDDDDDDD
DDDDDDGGGGGGGQQQKKKKKVVVVVVVVVVVVVVVVIIIJJJJJJJJJTTTTTTTTTUUUUUAAAAAAAAAAVOOOOONIIIIIYIIIINNNNNKNNNNNNNNNOOOOOOOOOCCJNNNNNNNNNLLLLDDDDDDDDJD
DDDDDDDDDGGGGGQKKKKKKVVVVVVVVVVVVVVVVIIIIJJJJJJJCCCTTTTTTTUUUUUAAAAAAAAAAAOOOINNIIIIIIIININNNNNNNNNNNNNNNOOOOOOOOOCCCNNNNNNLNLLLLLPDLLDDDDDD
DDDDDDDDDDDDGGQKKKKKKVVVVVVVVVVVVVVVVIIIJJJJJJJCCCCCTTTTTTTUUUAAAAAAAAAAAZZOZINNIIIIIIINNNNNNNYYYYYNNNNNNOOOOOOOOOCCCCNNNNNLNNNLLLPPDDDDDDDD
DDDDDDDDDDDDDDBKKKKKKVVVVVVVVVVVVVVVVEIIIIICCJCCCCCCTTTTTTTUUUAAAAAAAAAAAZZZIIIIIIIIIIINNNNNNNNYYYNNNNNNNOOOOOOOOOCNNNNNNNPLLLLLLLLDDDDDDDDD
DDDDDDDDDDDDDBBIKKKKKVVVVVVVVVVVVVVVVEEIIICCCCCCCCCCTTTTTUUUUUAAAAAANNNAAZZZZIIIIIIIIIIIIINNNNYYYYYNNNNNNOOOOOOOOOCNNNNNNNPPLLLLLLLLLDDDDDDD
DDDDDDDDDDDDDDBIIKKKKKKKVVVVVVVVVVVVVEEEICCCCCCCCCCCCCCTUUUUUUUAAAAANNNAKZZIIIIIIIIIIIIINNNNNNYYYYYYNNNNNOOOOOOOOOCCNNNNNNPPPLLLLLLLDDDDDDDD
DDDDDDDDDDDDBDBBKUKKKKKKVVVVVVVVVVEEEEEEEEECCCCCCCCCCCTTTUUUUUUAAAKKNKKKKBZIIIIIIIIIIIIIIIYYYNYYYYYYNBBNNNOOOOOOONNNNNNNNNPPPLPLLLLLDDDDDDDD
DDWDWDDDWDDDBBBYKKKKKCCCVVVVEEEEEEEEEEEEEECCCCCCCCCCEETTTBUUUUUUUKKKNKKKBBBBTIIIIIIIIIIIIIYYNNYYYYYYYBBNNNOOOOOOOOOOONNNNNPPPPPLPLLLTDDDDDDD
DWWWWWWDWDDBBBBBKKBKKCCCVVVVEEEEEEEEEEXEEEECCLVVCCCCJJJJBBUUUUUUUKKKNNKKKKBBTTIIIIIIIIIIIJYYYYYYYYYYYYBBNNOOOOOOOOOOONNPPPPPPPPPPPTTTMMMMMMD
TTTWWWWWWDDBBBBBBBBKKKCCVVVVEREEEEEEEEEEEELLLLCVCCCKJJJBBBUUUTTTTTKKKKKKKBBBBBIIIIDIIIIJJJUYYYYYYYYYBBBBBNOOOOOOOOOOONNNPPPPPPPQPPTTTMMMMMMM
TTWWWWWWWBBBBBBBBBBKKKBBVVVVRRREEEEEEEEEELLLLLCCCLCLJJBBBBUUUTTTMTKKKKKKBBBBBIIIIIIPIIJJJJJJYYYYYYYYBBBBBBOOOOOOOOOOONNNNPPPPPPPPPTTTTMFMMMM
TTTWWWWYWWBBBBBBBBBBKBBBBRRRRRREEYEEEERELLLLLLLLCLLLJJBBBBTTUUTTTTTKTKKKBBBBBIIIIIPPIIJJJJJJJYYYYYYYBBBBBBNOOOOOOOOOONNNPPPPPPPPTTTFFNFFFFMM
TOOWWWWYXYBYYYBBBBBBBBBBBRRRRRRREEEEERRRRLLLLLLLLLLLLLBBBBTTTTTTTTTTTKKBBBBBBBIIIJJPIIJJJJJJJJJYYYBBBBBBBBBOOOOOOOOOONNPPPPPPPPPTTTFFFFFFFFM
TTOOWYYYYYYYYYBBBBBBBBBBRRRRRRRRERRRRRRRRLLLLLLLLLLLLBBBBTTTTTTTTTTTKKKBKBJBBBBIIJJJJJJJJJJJJJJYYYBBBBBBBBBBBBGYGGGGGGNPPPPPPPTTTTFFFFFFFFFM
TTOTWPYYYYYYYYBYBBBBBBBBRRRRRRRRRRRRRRRRRLKLLLLLLLLLBBBBTTTTTTTTTTTTKKKKKKBBBBBIJJJJJJJJJJJJJJJJYYYBBBDDDDBBBBGYGGGGGGGPPPPPPPTTTTTTTFFFFMMM
TTTTWYYYYYYYYYYYYBBBBBBEEERRRRRRRRRRRRRRLLLLBBLLLLLLBBBBBTTTTTTTTTTTKKKKKKKKBBEIEEJJJJJJJJJJBBYYYYYBBBDDDDDGGGGGGGGGGGGGPPPPZPTTTTTTTFFFFMMM
TTTTTYYYYYYYYYYYBBBBBBBEEERRRRRERRRRRJRRRLRRRBBLLBBLBBBBBNNGTTTTTTTTKKKKKKKKBBEEEEEEEJJJJJJOBBBFRRYBBDDDDDGGGGGGGGGGGGGGGPPPZZZTTTTTTTFFFMMM
TTTTTYYYYYYYYYYBBBBBBBEEEEEEEERERRRRRJJRRRRRRRBLBBBBBBBBNNNTTTTTTTTTKKKKKKKKBBKKEEWEEJEJJWBBBFAFRRRDDDDDDDDGGGGGGGGGGGGGGGZPPZZZTZZTTTFFMMMM
TTTTYYYYYYYYYYYYBBBBBEEEEEEEEEEERRRJRJJRRRRRRRBBBBBBBBBBNNNNTTTTTTTTKKKKKKKKKKKEEEWWEEEEEBBBBFFFRRRRRDDDDDDDGGGGGGGGGGGZZKZZZZZZTZZTTTTTTTMM
TTTTTYYYYYYYYYYYBBBEEEEEEEEEEEEEERRJJJJRRRRRRRBBBBBBBBBNNNNNNNTTTTTKKKKKKKKHHHHHHHWWWWWWWJBBBFFFFFFFRDDDDDDDGGGGGGGGGGZZZZZZZZZZZZZZTTTMMMMM
TTTTTTYYYYYYYYOBBRBEEEEEEEEEEEEEERRJJJJJJRRRRRBBBBBBBBBBNNNNNNTTTTTTKKKKKKKHHHHHHHOWWWWWWJJBFFFFFFFURRDDDDDDDGGGGGGGGGGZZZZZZZZZZZZZTZTMMMMM
TTTYYYYYYYYYYYYBRRGEEEEEEEEEEEEEERJJJJJJJRRRBBBBBUUBBBBBNNNNNTTTTTTTKHHHHHHHHHHHHHWWWWWWWPPWFFFFFFFUYYYDDDDDDGGGGGGGGGZZZZZZZZZZZZZPZZMMMMMM
RRTTYYYYYYYYYYYBRRREEEEEEEEEEEEEEEJJJJJJJJRRRRBBUUUBBBBBNNNNNNNTTFHHHHHHHHHHHHHHHHWWWPWWPPPPFFFFFFUUYYYDDDDDDDGGGGGGGGGJZZZZZZZZZZZZZMMMMMMM
RRRRGGGYYYYYYYYRRRREEEEEEEEEEEEEEJAJJJJJJJJRRBBBUUUUUUUBBNNNNNNYYYHHHHHHHHHHHHHHHHPWWPWWPPPPFFFUFUAUUUUDDDDDDDGGGGGGGJJJZZZZZZZZZZZZZMMMMMMM
RRRRGRYYYYYYYYRRRRREEEEEEEEEEENEEJJJJJJJJPNPBBBBUYUUUUUUNNNNNNNYYYHHHHHHHOOHHHHHHHPPPPPPPPPPTTUUUUUUUUUUDDDDDDGGGGGGNNNJZZZZZZZZZZZZMMMMMMMM
RRRRRRRRYYYYYYRRRRREEEEEEAEEEENEEEBBJBBJPPPPPBUUUUUUUUNNNNNNNNYYYYHHHHHHHOOHHHHHHHPPPPPPPPPPTTTUUUUUUUUUUDDDDDDDDGGGNNNNNZZZZZZZZZZZZMMMZMMM
RRRRRRRRRRRYYRRRRRRRSESSSSEEEEEEBBBBBBJJPPPPPPPUUUUUUUNNNNNNNNNYYYHHHHHHHHHHHHHZZZZZZZPPPPPPPPUUUUUUUUUUUDDDDDDDDBBBNNNNNZZZZZZZZZZZZZZMZZZM
RRRRRRRRRRRRRRRRRRVRSSSSSEEEEEEBBBBBBBJJPPPPPPPUUUUUUUNUUWWNWNYYYYHHHHHHHHHCCPPZZZZZZZPPPPPPPCCUUUUUUUUUUDDDDDDDDBBBNNNNNZZZZTZZZZZHHZZZZZZM
RRRRRRRRRRWWRRRRRRRRSSSSEEEEEEEBBBBBBBBBPPPPPPUUUUUUUUUUUUUUWNYYYYHHHHHHHHHCPPPZZZZZZZZZZPPPPPPXXUUUUUUUDDDDDDDDDBBBBNNNNNZTTTZZZHHHHZZZZZZZ
RRRRRRWWWWWWRRRRRRSSSSSSEPPBDEBBBBBBBBBBBPPPPGGUUUUUUUUUUUUUUYYYYYYYYDHHHHHPPPAAPZZZZZZZZPPPPPPPPUUUUUUUUUDDDDDDDDBNNNNNNNZTTTTTHHHHHHHZZZZZ
RRRRRRWJWWWWRWRRRRSSSSSSSSBBBBBBBBBBBKEEBPPPPPUUUUUUUUUUUUUUXXPPPPYYDDHHHHHCCPCAAZZZZZZZZPPPPPPPSTTTUUUUUUDDDDDDDBBNNNNNNNNTNTHHHHHHHHZZZZZZ
RRRRRWWWWWWWWWWRRSSSSSSSSSSBBBBBBBBBKKKKKKPPVVVTTUUUUUUUUUUUUPPPPPPCUUHHHHHCCCCCAZZZZZZZZPPPPPSSSSSTUUUUUUDDDDDDDLBNNNNNNNNTNNHHHHHHHHZZZZZZ
RRRRRWWWWWWWWWWWWSSSSSSSSSSBBBBBBBBKKKKKKKKVVVVVVVUUUUUUUUUUPPPPPOPUUUHHHHHCCCAAAPPPPPPPVVVVPPPSSSSUUOUUDDDDDLDLLLLNNNNNNNNNNZHHHHHHHHZZZZZZ
RRRRRWWWWWWWWWWWWSSSSSSSSSSBBBBBBBKKKKKKKKKKVVVVVLUUUUUUUUUUUUPPPPPUUUHHHHHCCCCAAPPPPVVVVVVVVPOOOOSSOOUUUUUDDLLLLLLNNNNNNNNNEHHHHHHPPPIIIZZZ
RRRRRWWWWWWWWWWIWSSSSSSSSJBBEEEEEEEEEKKKKKKKVVVVVVUUUUUUUUJUJPPPPUPUUUHHHHHHHNNNAAPPPVVVVVHVVOOOOOOOOOUUUULDLLLLLLNNNNNNNNNNNHHHHHHHIIIIIIZZ
RRRRRWWWWWWWWWWWSSSSSSXXXIIIIEEEEEEEEKKKKKKVVVVVVVVUUUUUUUJJJPPPPPUUUUHHHHHHHNNNAVVVVVVVVVVOOOOOOOOOOUUUUYLLLLLLLLLNNNNNNNNNNNNNHHHHIIIIIZZZ
RRRRRRWWWWWWWWWWIISSSSUUUIIIIEEEEEEEEKKKKKKVVVVVVVVVVUUUUJUJJPPPPUUUBBBBBHHHHNNVAVVVVVVVVVVOVVOOOOOOOOLLLLLLLLLLLLLNNNNNNNNNNNNNHHHHIIIIIZZZ
RRRRRRWWWWWWWWWIIISSSSVVUIIIIEEEEEEEEKKKKKKKVVVVVVSVVVUUSSUUUPPPUUUUUUBBBHHHHNNVVVVVVVVVVVVVVVVOOOOOOOLLLLLLLLLLLLLNNNNNRKRNNNNNNIIIIIIIIIII
RRRRRRRWWWDWWKKTTISSSVVVUIIIIEEEEEEEEKKKKKKKVVVVVSSVVVVSSSUUQPUUUUUUUUNNBHHHHHNVVVVVVVVVUVVVVOOOOOOOOOOLLLLLLLLLLLLNNRRRRRRRRNNNNNIIIIIIIIII
RRRRRRRRWWDDDDTTTTVSSSVVUUVVEEEEEEEEEKKKKKKKKVUVVSSSSSSSSUUUUUUUUUUUNNNNNHHHHNNVVVVVVVVVUVUUVOOOOOFFOOOOOLLLLLLLLLWWWBRRRRRRNNNNNNNIIIIIIINN
RRRRRRRRRRDDDTTDTVVVVVVUUVVVEEEEEEEEEKKKKKKKULUVSSSSSSSSSUUUUUUUUUUUNNNNNHHHHNNVVVVVVVVVUUUUOOFFOOFOOOOLLLLLLLLLWWWWWBRRRRRRNNNNNNIIIIIIIIIN
RRRRRRARRRDDDDDDVVVVVVVVVVVVEEEEEEEEEKKKKKKUUUUVSSSSSSSSSSUUUUUUUUUUNNNNNHHHHNNVVVVVVVVVSUUOOUFFFFFFOFFLLLLLLLLLLWWWWWRRRRRRNNNNNNIINIIIINNN
RRRRRRRRRRRDDJJJVVVVVVVVVVVVEEEEEEEEEKKKKKKQUUUUUSSSSSSSSSLUUUUUNUNNNNNNNHHHHNNNVVVVVVVVUUUUUUJFFFFFFFLLLLLLLLLLLLWWWWRRRRNNNNNNNNNNNNIINNNN
RRRRRDDDRDRDDJJJJJJVVVVXVVXXEEEEEEEEEKKMKKKQUUUUUUSSSSSSSSSUUUVVNNNNNNNNNHHHHNNNNVVVNVVNHHUHUJJFFDFFFFFLLLLLLLLWLWWWWWWRRRNNNNNNNNNNNNNINNNN
RRRDDDDDDDDDDJJJJJJVVVXXXXXXVVVVVVKKMMMMMKKQQUUUUUSSSSUUUSOVVVVVDDNNNNNNNNNNNNNNNVNVNNNNNHHHHHHHFFFFFFFFLLLLLPWWWWWWWWWWRRRMNNNNNNNNNNNNNNNN
DDRDDDDDDDDJJJJJJJJJVXXXGXXXVVVVVVKKKMMMMKQQZZUUUUUSUUUUUUVVVVVVVVNNNNNNNNNNNNNNNNNNNNNNHHHHHHHHNNFFFFFFAAAFPPWWWWWWWWWWWWMMMMMNNNNNNNNNNNNN
DDDDDDDDDSSSSJJJJJJSVSSSXXXXXXVVLLKKMMMMMKQZZZZUUUUUUUUUUUUFVVVVVVNNNNNNNNNNNNNNNNNNNNNNHHHHHHHHHHHMFFFFFFFFPPWWWWWWWWWWWMMMMMMNNNNNNNNNNNNN
DDDDDDDDDDSSSJJJJJJSSSXSXXXXXXXVLLLLMMMMZZZZZZUUUUUUUUUUUUFFVVVVVVNNQNDNNNNNNNNNNNNNNNNNNHHHHHHHHHHMFFFFFFMPPPWWWWWWWWWWMMMMMMMNNNNNNNNNNNNN
DDDDDDSSDSSSSSJJJJSSXXXXXXXXXXXLLLLLMMMZZZZZZZZUUUUUUUUUUFFFFFVVVVQQQNNLLLLLNNNNNNNNNNNNNHHHHHHHHHHMMFFFFFMMMMWWWWWWWWWWWMMMMMMNMMNNNNNNNNNN
DDDSDDSSSSSSSSSSSSSSXXXXXXXXXXXXLLLLLLZZZZZZZZZUUUUUUUUUUFFFFFVVVVVVQQQLLLLLLLLLLLNNNNNNNHHHHHHHHHMMMMMMMMMMMMBBWWWWWWWWMMMMMMMMMMNNNNNNNNNN
DDDSSSSSSSSSSSSSSSSSXXXXXXXXXXLLLLLLLLZZZZZZZUUUUUUUUUUUUFFFFFFFVVVQQQQLLLLLLLLLLLNNNDDDDDDDHHHHHHMMMMMMMMMMMMWWWWWWWWWMMMMMMMMMMFNNNNNNNNNN
DDDDGGGSSSSSSSSSLLSXXXXXXXXXXXXXLLLLLQZZZZZZZUUUUUUUUUUHHFFFFFFFVRRVQQQLLLLLLLLLLLDDDDDDDDDDHHHJMMMMMMMMMMMMMWWWWWWWWWWSMMMMMMMMMNNNNNNNNNNN
DDGGGGSSSSSSSSSSLLSSSSAAAXXAXXXXLLLLLLDZZZZZZZZUUUUUUHHHHFFFFFFFVRVVVVKLLLLLLLLLLLDDDDDDDDDDHHHJMMMMMMMMMMMMMMCCCCWWWWMMMMMMMMMMMMMNNNNNNNNN
GGGGGGSSBSSSSSLSSLLLSSSAAAAAOXXXLLLZZZZZZZZZZZZZUUSSSSHHHHOOFFFOOVVVVVQLLLLLLLLLLLDDDDDDDDDDHHJJMMMMMMMMHHMMQWQQQCWWWCMMWMMMMMMMMMMNNNNNNJJJ
GKKGGGSSSSSSSSLLLLLLLLSAAALAOXOXLLOOZZZZZZZZZZZZUUUSSSSHHOOOFOOOOVVVVDQLLLLLQQQVDDDNNNDDDDDDPHJJJMMMMMMMHQQQQQQQQCCWWCMMMMMMMMMMMMMMMNNNJJJJ
GKKKGSSSSSSSSSALLLLLLLLLAAAAOOOOLLOOZZZZZZUZZMZSUSSSSSSHOOOOOOOOVVVVVQQLLLLLQQQVVVDNNNDDDDDDPHJJJJJMMMMHHHQQQQQQIICWWCCCCMZMMMMMMMMMMMNJJJGJ
GKKKSSSNNSSSSSLLLLLLLLLAAAAAAOOOOOOZZZZZZUUUUMSSSSSSSSSSOOOOOOOOOVVVVVVLLLLLQQQNNNDNNNNNDDDDPPJJJYYMMHHHHHHQQQQQQCCCCCCCMMMMMMMMMMJJJJJJGGGG
GKKKKKKKSSSSJSLLLLLLLLLAAAAAAOOOOOOOZZZZZUUUUMSSSSSSSSSSSSSGGGOOVVZVVVVQQQQQQQQQQQDNNNNNDDDDPPPJLLYMMMHHHHFYYQQQQCCCCCCCMMMMMMMMMJJJJJJGIGGG
GKKKKKKKKKSSSSLLLLLLLLLAAAAAAAOOAOOOOOZZZUUUUUSSSSSSSSSSSGGGGGGOOVVVVVVQQQQQQQQQQQDNNNNNNNDDTPLLLLLHHHHYYYFYYQQQQCCCCCCCMMMMMMMMMJJJJJJGGGGG
KKKKKKKKKKKKSLLLLLLLLLLAAAAAAAAOAOOOOOOZOAUUUUUSSSSWSWSSWGGGMGGOOOOVVVVQQQQQQQQQQQDNNNNNNNDDLLLLLLLHHHHYYYYYYYYQQCCCCCCCCCMMMMMJJJJJJJJJGGQQ
YKKKKKKKKKKKLLLLLLLLLLLAAAAAAAAOAOOOOOOOOAAAUUUKSWWWSWSWWGGGGGGGGOVVVVQQQQQQQQQQQTTNNNNNNNDDTLLLLLLHLHHYYYYYYYYYCCCCCCCCCCYMMMMJJJJJJJJJJGQQ
KKKKKKKKKKKKRLLRLLLLLLLAAAAAAAAAAOOOMMOOOAAAUUKKSSWWWWWWWWGGGGGGGGGVBVBBBQQQQQQQQQTNNNNNNNDDDDDLLLLYYYYYYYYYYYCCCYYCYYCCYYYMMMMJJJJJJJJGGGQQ
KKKKKKKKKKKRRRLRLLLLLAAAAAAAAAMAAMMMMMMMOOAAAAKKKSWWWKWWWGGGGGGGGBBBBVBQQQQQQQQQQQINNNNNNNDDDDDLLLLYYYYYYYYYFYCYYYYYYYYCYYYYGMJJJJJJFJJJGFFF
KKKKKKKKKKRRRRRRRLLLLLAAAAAAAMMMMMMMMMMMOAAAAAAKKSKWWKKKKRGGGAGGBBBBBBBBQQQQPQQPPPTNNNNNNNDDDDDLLLLYYYYYYYYYFYYYYYYYYYYYYYGYGGJJJJJFFFFJFFFF
KKKKKKKKTKRRRRMLLLLLLLAAAAAAMMMMMMMMMMCMSAAAAAAKKKKKKKKKKGGGGAGGBBUUUUBBQQPPPQPPPTTNNNNNNNTTTTLLLCYYYYYYYYFFFFYYYYYYYYYYYYGGGGGGGJJJFFFJFHFF
YKKKKKKKTRRRRMMZZLLLLPMMAMAMMMMMMMMMMCCAAAAAAKKKKKKKKKKKKGGGGGBGBBUUUUUUERRPPPPPPTTTMTTTTTTTTLLLLCYYYYYYYYFFKKKKYKKKYYYKKYGGGGGGGJFFFFFFFFFF
KKKKQKTKTTRRRMMMMLMMZMMMMMMMMMMMMMMMMAAAAAAAAKKKKKKKKKKKKBBBBBBBBDUUUUUURRPPPPPPPLLTMMMTTTTMTLLLLCYYYYYYYYFFKKKKKKKKKKKKKYGGGGGGGJJJFFFFFFFF
QQQKQTTTTTRRMMMMMMMMMMMMMMMMMMMMMMMMMMMAAAAAAAKKKKKKKKKKKBBBBBBBBDUUURRRRRRRRRPPLLLMMLMTTTTMMLLLLCYYYYYYYFFKKKKKKKKKKKKKKKGGGGGGGGJFFFFFFFFF
QQQQQTTYTRRRMMMMMMMMMMMMMMMMMMMMMMMMMMAAAAAAAAACKKCKKKKKBBBBBBBBDDDDHHRRRRRRRRPPLLLLLLTTTTMMMMCCCCYYYYYYYFKKKKKKKKKKKKKKKGGGGGGGGGGFFFFFFFFF
QQQQQTTTTTTRMMMMMMMMMMMMMMMMMMMMMMMMMAAAAAACCACCCCCKKKKKKBBBBBBDDDDDHHRRRRRRRRRRLLLLLYYYTTMMMMCCCCYYYYYYYFKKQKKKKKKKKKKGKGGGGGGGGFFFFFFFFFFF
QQQQTTTTTTTTTMMMMMMMMMMMMPPPPMMMMMMMOAAAAAAUCCCCCCKKKKKKKBBBBBDDDDDDDZRRRRRRRRLLLLLLLLYYYMSMMMMNNNYYYYYYYFKKKKKKKKKKKKKGGGGGGGGGFFFFFFFFFFFF
QQQQQQTTTTTTTTMMMMMMMMMMMMMPMMMMMMMMMMAAACCCCCCCCCKKKKKKBBBBBBZZZZDDZZRRRRRNRLLLLLLLLLYLLMMMMMMNNNYYYYYYYFKKKKKKKKKKKKGGGGGPMMGFFFFFFFFFFFFF
QQQUQQTVTTTTTTMMMMMMMMMMMPPPDMMQMQQMMAAAACCCCCCCVCKKKKKKBBBBBBZZZZZZZZRRRRRRRLLLLLLLLLLLMMMMMMMNNNYYYYYYYNKKKKKKKKKKKKGGGGPPMFFFFPPFFFFFJFFF
QQQUUQQQTTTTTTMMMMMMMMMMMMPDDDMQQQMMMAAACCCCVCCVVKKKKKKBBBBBBBZZZZDDDDDRRRRRLLLLLLLLLLLMMMMMMMMMDNYYYYYYYXXXKKKXKKKKKGGGGGPPMPPFPPPPFFJJJFJJ
QUUUUUQQQTGTTTMMMMMMMMMMMMDDDDDDDQQAMAAACCCCVVVVVKKKKKKBBBBBBZZZZZDDDDRRRRRRLLLLLLLLLLPMMMMMMMMNNNNNNNNNNXXXXXXXXKKKKGGGGGGPPPPPPPPPFJJJJJJJ
UUUUUUUQQQTTTTTMMMMMMMMMMMMDDDDDDQQAAAAACCGVVVVVVVVKVKLLBBBBBBQZZDDDDDDDRDRLLLLLLLLLLLMMMMMMMMNNNNNNNNNXXXXXXXXXXXXKKGGGGGPPPPPPPPOOJJJJJJJJ
BUUUUUUQQQQQTTTMMMMMMMMDDMDDDDDDQQQQAAAGGGGVVVVVVVVVVVVLBBBBQQQQDDDDDDDDDDDLLLLLLLLLLLMMMMMMMMAANNNNNNNXXXXXXXXXXXXGGGGGGGGPPPPPPPOOOOJJJJJJ
UUUUUUQQQQQQPTTMMMMMMMDDDDDDDDDDQQQQAAVGGGGVVVVVVVVVVVVVVVBBQDQDDDDDDDDDDDJLLLLLLLLLLLMVVMMMMAANNNNNNXXXXXXXXXXXXXGGGGGGGGGPPPPPOOOOJJJJJJJJ
UUUUUUQQQQQQQTMMMMMMMMMDDDDDDDDDQQQAAVVVVVVVVVVVVVVVVVVVBBBBQDDDDDDDDDDDDDJLLLLLLLLLLLLLVMAAAAAAANNNNXXXXXXXXXXXGGGGGGGGGGGGGDDPOOOOJJJJJJJJ
SSSUUDDQQQQQQMMMMMMMMMMDDDDDDDDDQQQAAVVVVVVVVVVVVVVVVVVVVVBBQDDDDDDDDDDDDDJLLLLLLLLLLLLLLLLAAAAAAANNNNXXXXXXXXXXXXGGGGGGGGGGGGDDDOONNJJJJJJJ";
        }
    }
}