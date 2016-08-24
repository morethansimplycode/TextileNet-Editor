using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Textile
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary> A ported code. </summary>
    /// <remarks> Oscvic, 24/08/2016. </remarks>
    ///-------------------------------------------------------------------------------------------------
    public class PortedCode
    {


        public PortedCode()
        {
            $this->setDocumentType($doctype)->setRestricted(false);
        
        $this->uid = 'textileRef:'.$uid.':';
        $this->linkPrefix = $uid.'-';
        $this->a = "(?:$this->hlgn|$this->vlgn)*";
        $this->s = "(?:$this->cspn|$this->rspn)*";
        $this->c = "(?:$this->clas|$this->styl|$this->lnge|$this->hlgn)*";
        $this->cls = '(?:'.
            "$this->clas(?:".
                "$this->lnge(?:$this->styl)?|$this->styl(?:$this->lnge)?".
                ')?|'.
            "$this->lnge(?:".
                "$this->clas(?:$this->styl)?|$this->styl(?:$this->clas)?".
                ')?|'.
            "$this->styl(?:".
                "$this->clas(?:$this->lnge)?|$this->lnge(?:$this->clas)?".
                ')?'.
            ')?';
            if ($this->isUnicodePcreSupported()) {
            $this->regex_snippets = array(
                'acr'   => '\p{Lu}\p{Nd}',
                'abr'   => '\p{Lu}',
                'nab'   => '\p{Ll}',
                'wrd'   => '(?:\p{L}|\p{M}|\p{N}|\p{Pc})',
                'mod'   => 'u', // Make sure to mark the unicode patterns as such, Some servers seem to need this.
                'cur'   => '\p{Sc}',
                'digit' => '\p{N}',
                'space' => '(?:\p{Zs}|\h|\v)',
                'char'  => '(?:[^\p{Zs}\h\v])',
            );
            } else {
            $this->regex_snippets = array(
                'acr'   => 'A-Z0-9',
                'abr'   => 'A-Z',
                'nab'   => 'a-z',
                'wrd'   => '\w',
                'mod'   => '',
                'cur'   => '',
                'digit' => '\d',
                'space' => '(?:\s|\h|\v)',
                'char'  => '\S',
            );
            }
        $this->urlch = '['.$this->regex_snippets['wrd'].'"$\-_.+!*\'(),";\/?:@=&%#{}|\\^~\[\]`]';
        $this->quote_starts = implode('|', array_map('preg_quote', array_keys($this->quotes)));
            if (defined('DIRECTORY_SEPARATOR'))
            {
            $this->ds = DIRECTORY_SEPARATOR;
            }
            if (php_sapi_name() === 'cli')
            {
            $this->setDocumentRootDirectory(getcwd());
            }
            elseif(!empty($_SERVER['DOCUMENT_ROOT'])) {
            $this->setDocumentRootDirectory($_SERVER['DOCUMENT_ROOT']);
            }
            elseif(!empty($_SERVER['PATH_TRANSLATED'])) {
            $this->setDocumentRootDirectory($_SERVER['PATH_TRANSLATED']);
            }
        }
    }
}
